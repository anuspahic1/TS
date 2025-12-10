namespace Shared.DataTransferObjects
{
    public record ReservationForCreationDto
    {
        public Guid UserId { get; init; }
        public Guid EventId { get; init; }
        public decimal TotalPrice { get; init; }
    }

}
