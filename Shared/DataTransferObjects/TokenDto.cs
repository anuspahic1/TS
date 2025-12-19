namespace Shared.DataTransferObjects
{
    public record TokenDto(string AccessToken, string RefreshToken, bool twoFactorEnabled, bool hasAuthenticatorKey);
}
