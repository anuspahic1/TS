namespace Shared.DataTransferObjects
{
    public record RewardDto
    {
        public Guid Id { get; init; }
        public string Description { get; init; }
        public string? ImageUrl { get; init; }
        public DateTime GrantedAt { get; init; }
        public Guid UserId { get; init; }
        public string UserFullName { get; init; }
    }
}
