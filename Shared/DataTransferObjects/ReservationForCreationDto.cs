namespace Shared.DataTransferObjects
{
    public record ReservationForCreationDto
    {
        public Guid UserId { get; init; }
        public decimal TotalPrice { get; init; }
        public IEnumerable<TicketForCreationDto>? Tickets { get; init; }

    }

}
