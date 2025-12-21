using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<TfaSetupDto> GetTfaSetup(string email);
        Task<TfaSetupDto> PostTfaSetup(TfaSetupDto tfaModel);
        Task<TokenDto> VerifyTfa(VerifyTfaDto dto, string email);
        Task<TfaSetupDto> DeleteTfaSetup(string email);
    }
}
