using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ReservationForCreationDto
    {
        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; init; }

        [Range(0, 100000, ErrorMessage = "Total price must be a positive value.")]
        public decimal TotalPrice { get; init; }

        public IEnumerable<TicketForCreationDto>? Tickets { get; init; }

    }

}
