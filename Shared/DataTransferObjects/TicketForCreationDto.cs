using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record TicketForCreationDto
    {
        [Required(ErrorMessage = "Ticket price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Ticket price must be greater than 0.")]
        public decimal Price { get; init; }

        [MaxLength(10, ErrorMessage = "Seat number cannot exceed 10 characters.")]
        public string? SeatNumber { get; init; }
    }
}
