using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
            //_jwtConfiguration = _configuration.Get("JwtSettings");
            _jwtConfiguration = _configuration.Value; //ilma
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

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var twoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(_user);
            var hasAuthenticatorKey = await _userManager.GetAuthenticatorKeyAsync(_user) != null;

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(
                accessToken,
                refreshToken,
                twoFactorEnabled,
                hasAuthenticatorKey
            );
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user is null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<TfaSetupDto> GetTfaSetup(string email)
        {
            // refactor this email with var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByNameAsync(email);

            if (user is null)
                throw new TfaBadRequest();

            //var isTfaEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            var isTfaEnabled = true; // hardcoded for now

            var authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            if (authenticatorKey is null)
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            }

            var formattedKey = GenerateQRCode(email, authenticatorKey);

            return new TfaSetupDto
            {
                IsTfaEnabled = isTfaEnabled,
                AuthenticatorKey = authenticatorKey,
                FormattedKey = formattedKey
            };
        }

        public async Task<TfaSetupDto> PostTfaSetup(TfaSetupDto tfaModel)
        {
            var user = await _userManager.FindByNameAsync(tfaModel.Email);
            var isValidCode = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, tfaModel.Code);
            if (isValidCode)
            {
                await _userManager.SetTwoFactorEnabledAsync(user, true);
                return new TfaSetupDto 
                { 
                    IsTfaEnabled = true 
                };
            }
            else
            {
                throw new TfaBadRequest();
            }
        }

        public async Task<TokenDto> VerifyTfa(VerifyTfaDto dto, string email)
        {
            var user = await _userManager.FindByNameAsync(email);

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

        public async Task<TfaSetupDto> DeleteTfaSetup(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
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

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.NameIdentifier, _user.Id) 
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
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
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

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
    }
}
