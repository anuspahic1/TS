namespace Shared.DataTransferObjects
{
    public record RewardForCreationDto
    {
        public string Description { get; init; }
        public string? ImageUrl { get; init; }
    }
}
