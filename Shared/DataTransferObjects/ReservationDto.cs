namespace Shared.DataTransferObjects
{
    public record ReservationDto
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public decimal TotalPrice { get; init; }
        public Guid UserId { get; init; }
        public string UserFullName { get; init; }
        public Guid EventId { get; init; }
        public string EventName { get; init; }
        public DateTime EventDate { get; init; } 
        public int TicketsCount { get; init; } 
        public string Status { get; init; } 
    }
}
