using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class Ticket
    {
        [Column("TicketId")]
        public Guid Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(10)]
        public string? SeatNumber { get; set; }

        public bool IsReserved { get; set; }

        [MaxLength(200)]
        public string? QRCode { get; set; }

        [ForeignKey(nameof(Reservation))]
        public Guid? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }
        public Event? Event { get; set; }
    }
}
