namespace Shared.DataTransferObjects
{
    public record AppUserForCreationDto
    {
        public string FullName { get; init; }
        public string Email { get; init; }
        public string? BankAccountNumber { get; init; }
    }
}
