using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Reservation
{
    [Column("ReservationId")]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Range(0, 100000, ErrorMessage = "Total price must be positive.")]
    public decimal TotalPrice { get; set; }

    [Required(ErrorMessage = "UserId is required.")]
    public string UserId { get; set; }
    public AppUser? User { get; set; }

    [Required(ErrorMessage = "EventId is required.")]
    public Guid EventId { get; set; }
    public Event? Event { get; set; }

    public ICollection<Ticket>? Tickets { get; set; }
}
