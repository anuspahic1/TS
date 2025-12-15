namespace Shared.DataTransferObjects
{
    public record EventDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public decimal MinTicketPrice { get; set; }
        public DateTime EventDate { get; set; }
        public string LocationName { get; init; }
    }
}
