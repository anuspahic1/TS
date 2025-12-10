using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Reservation
    {
        [Column("ReservationId")]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(AppUser))]
        public Guid UserId { get; set; }
        public AppUser? User { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }
        public Event? Event { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
