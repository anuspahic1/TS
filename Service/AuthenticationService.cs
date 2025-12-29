using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IOptionsSnapshot<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;
        private User? _user;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private readonly UrlEncoder _urlEncoder;
        private readonly IRepositoryManager _repository;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptionsSnapshot<JwtConfiguration> configuration, UrlEncoder urlEncoder, IRepositoryManager repository)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;
            _urlEncoder = urlEncoder;
            _repository = repository;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)
            {
                if (userForRegistration.Roles != null && userForRegistration.Roles.Any())
                {
                    await _userManager.AddToRoleAsync(user, userForRegistration.Roles.First());
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                var appUser = new AppUser
                {
                    Id = Guid.Parse(user.Id),
                    FullName = $"{userForRegistration.FirstName} {userForRegistration.LastName}",
                    Email = user.Email
                };

                _repository.AppUser.CreateUser(appUser);
                await _repository.SaveAsync();
            }

            return result;
        }

        public async Task<TokenDto> Authenticate(UserForAuthenticationDto dto)
        {
            _user = await _userManager.FindByNameAsync(dto.UserName);

            var roles = await _userManager.GetRolesAsync(_user);
            var isAdmin = roles.Contains("Administrator");

            if (isAdmin)
            {
                var tokenDto = await CreateToken(populateExp: true);

                return tokenDto with
                {
                    RequiresTwoFactor = false
                };
            }

            var hasAuthenticator = await _userManager.GetAuthenticatorKeyAsync(_user) != null;
            
            var preAuthToken = CreatePreAuthToken(_user);

            return new TokenDto(
                AccessToken: null,
                RefreshToken: null,
                TwoFactorEnabled: true,
                HasAuthenticatorKey: hasAuthenticator,
                RequiresTwoFactor: true,
                PreAuthToken: preAuthToken
            );
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong name or password.");

            return result;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;
            _user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            var twoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(_user);
            var hasAuthenticatorKey = await _userManager.GetAuthenticatorKeyAsync(_user) != null;

            return new TokenDto(
                AccessToken: accessToken,
                RefreshToken: refreshToken,
                TwoFactorEnabled: twoFactorEnabled,
                HasAuthenticatorKey: hasAuthenticatorKey,
                RequiresTwoFactor: false,
                PreAuthToken: null
            );
        }

        public async Task<TokenDto> RefreshToken(string refreshToken)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new RefreshTokenBadRequest();

            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<TokenDto> PostTfaSetup(TfaSetupDto dto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new TfaBadRequest();

            var isValidCode = await _userManager.VerifyTwoFactorTokenAsync(
                user,
                _userManager.Options.Tokens.AuthenticatorTokenProvider,
                dto.Code
            );

            if (!isValidCode)
                throw new TfaBadRequest();

            await _userManager.SetTwoFactorEnabledAsync(user, true);

            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<TfaSetupDto> DeleteTfaSetup(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user is null)
            {
                throw new TfaBadRequest();
            }
            else
            {
                await _userManager.SetTwoFactorEnabledAsync(user, false);
                return new TfaSetupDto 
                { 
                    IsTfaEnabled = false 
                };
            }
        }

        public async Task<TfaSetupDto> GetTfaSetupByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new TfaBadRequest();

            var authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            if (authenticatorKey is null)
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            }

            return new TfaSetupDto
            {
                IsTfaEnabled = await _userManager.GetTwoFactorEnabledAsync(user),
                AuthenticatorKey = authenticatorKey,
                FormattedKey = GenerateQRCode(user.Email, authenticatorKey)
            };
        }

        public async Task<TokenDto> VerifyTfaByUserId(VerifyTfaDto dto, string userId, string authStage)
        {
            if (authStage != "2fa_pending")
                throw new UnauthorizedAccessException();

            var user = await _userManager.FindByIdAsync(userId) ?? throw new TfaBadRequest();

            var valid = await _userManager.VerifyTwoFactorTokenAsync(
                user,
                _userManager.Options.Tokens.AuthenticatorTokenProvider,
                dto.Code
            );

            if (!valid)
                throw new TfaBadRequest();

            _user = user;
            return await CreateToken(populateExp: true);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(GetSecret());
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, _user.UserName),
                new(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.NameIdentifier, _user.Id)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
                //new Claim(ClaimTypes.Role, AppRoles.User)
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetSecret())),
                ValidateLifetime = false, //
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        private string GenerateQRCode(string email, string unformattedKey)
        {
            return string.Format(AuthenticatorUriFormat, _urlEncoder.Encode("EntrioX Two-Factor Auth"), _urlEncoder.Encode(email), unformattedKey);
        }

        private string CreatePreAuthToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new("auth_stage", "2fa_pending")
            };

            var token = new JwtSecurityToken(
                issuer: _jwtConfiguration.ValidIssuer,
                audience: _jwtConfiguration.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(3),
                signingCredentials: GetSigningCredentials()
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GetSecret()
        {              
            var secret = Environment.GetEnvironmentVariable("SECRET");
            if (string.IsNullOrWhiteSpace(secret))
                throw new Exception("JWT SECRET is not configured");
            return secret;
        }

    }
}
