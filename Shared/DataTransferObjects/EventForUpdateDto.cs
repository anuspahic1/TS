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
    }
}
