namespace Shared.DataTransferObjects
{
    public record EventForCreationDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}
