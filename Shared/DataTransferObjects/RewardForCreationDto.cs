using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record RewardForCreationDto
    {
        [Required(ErrorMessage = "Reward description is required.")]
        [MaxLength(150, ErrorMessage = "Description max length is 150.")]
        public string Description { get; init; }

        [MaxLength(200, ErrorMessage = "Image URL max length is 200.")]
        [Url(ErrorMessage = "ImageUrl must be a valid URL.")]
        public string? ImageUrl { get; init; }
    }
}
