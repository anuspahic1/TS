using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey(nameof(Location))]
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
