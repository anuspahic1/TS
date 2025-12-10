namespace Shared.DataTransferObjects
{
    public record EventDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime Created { get; init; } 
        public string LocationName { get; init; }
    }
}
