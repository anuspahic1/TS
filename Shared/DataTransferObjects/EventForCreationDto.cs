using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record EventForCreationDto
    {
        [Required(ErrorMessage = "Event name is required.")]
        [MaxLength(100, ErrorMessage = "Event name max length is 100.")]
        public string Name { get; init; }

        [MaxLength(500, ErrorMessage = "Description max length is 500.")]
        public string? Description { get; init; }

        [Range(0, double.MaxValue, ErrorMessage = "Min ticket price must be >= 0.")]
        public decimal MinTicketPrice { get; init; }

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime EventDate { get; init; }

        // The Id of the user who created the event. If authentication is added,
        // this should be set from the authenticated user instead of the client payload.
        public Guid CreatorId { get; init; }
        public Guid LocationId { get; init; }

        public IEnumerable<ReservationForCreationDto>? Reservations { get; init; }
        public IEnumerable<TicketForCreationDto>? Tickets { get; init; }
        public int Capacity { get; init; }
    }
}
