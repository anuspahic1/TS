using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Location
{
    [Column("LocationId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Location name is required.")]
    [MaxLength(100, ErrorMessage = "Location name max length is 100.")]
    public string Name { get; set; }

    [MaxLength(100, ErrorMessage = "Address max length is 100.")]
    public string? Address { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
    public double? GeoLongitude { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
    public double? GeoLatitude { get; set; }

    public ICollection<Event>? Events { get; set; }
}
