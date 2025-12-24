namespace Shared.DataTransferObjects
{
    public record AppUserDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }

        public int LoyaltyPoints { get; init; }

    }
}
