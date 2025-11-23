using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Location
    {
        [Column("LocationId")]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        public double? GeoLongitude { get; set; }
        public double? GeoLatitude { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
