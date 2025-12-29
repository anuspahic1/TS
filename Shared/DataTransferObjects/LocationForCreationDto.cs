using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record LocationForCreationDto
    {
        [Required(ErrorMessage = "Location name is required.")]
        [MaxLength(100, ErrorMessage = "Location name max length is 100.")]
        public string Name { get; init; }

        [MaxLength(100, ErrorMessage = "Address max length is 100.")]
        public string? Address { get; init; }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public double? GeoLongitude { get; init; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public double? GeoLatitude { get; init; }

        public IEnumerable<EventForCreationDto>? Events { get; init; }
    }
}
