namespace Shared.DataTransferObjects
{
    public record TicketDto
    {
        public Guid Id { get; init; }
        public decimal Price { get; init; }
        public string? SeatNumber { get; init; }
        public bool IsReserved { get; init; }
        public string? QRCode { get; init; }
        public Guid EventId { get; init; }
        public string EventName { get; init; }
    }
}
