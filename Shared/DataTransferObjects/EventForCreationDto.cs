namespace Shared.DataTransferObjects
{
    public record EventForCreationDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public IEnumerable<ReservationForCreationDto>? Reservations { get; init; }
        public IEnumerable<TicketForCreationDto>? Tickets { get; init; }

    }
}
