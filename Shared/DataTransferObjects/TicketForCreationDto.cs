namespace Shared.DataTransferObjects
{
    public record TicketForCreationDto
    {
        public decimal Price { get; init; }
        public string? SeatNumber { get; init; }
        public Guid EventId { get; init; }
    }
}
