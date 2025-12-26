namespace Shared.DataTransferObjects
{
    public record TokenDto(string AccessToken, string RefreshToken, bool TwoFactorEnabled, bool HasAuthenticatorKey, bool RequiresTwoFactor);
}
