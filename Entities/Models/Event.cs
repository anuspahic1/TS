using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Event
    {
        [Column("EventId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
