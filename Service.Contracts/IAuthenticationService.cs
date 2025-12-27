using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<TokenDto> Authenticate(UserForAuthenticationDto dto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<TokenDto> PostTfaSetup(TfaSetupDto tfaModel, string userId);
        Task<TfaSetupDto> DeleteTfaSetup(string email);
        Task<TfaSetupDto> GetTfaSetupByUserId(string userId);
        Task<TokenDto> VerifyTfaByUserId(VerifyTfaDto dto, string userId, string authStage);
    }
}
