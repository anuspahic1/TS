using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record EventForUpdateDto
    {
        [Required(ErrorMessage = "Event name is required.")]
        [MaxLength(100, ErrorMessage = "Event name max length is 100.")]
        public string Name { get; init; }

        [MaxLength(500, ErrorMessage = "Description max length is 500.")]
        public string? Description { get; init; }

        public Guid? LocationId { get; init; }

        public int Capacity { get; init; }
        [Range(0, double.MaxValue, ErrorMessage = "Min ticket price must be >= 0.")]
        public decimal MinTicketPrice { get; init; }
        [Required(ErrorMessage = "Event date is required.")]
        public DateTime EventDate { get; init; }
    }
}
