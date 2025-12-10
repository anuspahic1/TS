namespace Shared.DataTransferObjects
{
    public record RewardForCreationDto
    {
        public Guid UserId { get; init; }
        public string Description { get; init; }
        public string? ImageUrl { get; init; }
    }
}
