using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Ticket
{
    [Column("TicketId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Ticket price is required.")]
    [Range(0.01, 10000, ErrorMessage = "Ticket price must be greater than 0.")]
    public decimal Price { get; set; }

    [MaxLength(10, ErrorMessage = "Seat number cannot exceed 10 characters.")]
    public string? SeatNumber { get; set; }

    public bool IsReserved { get; set; } = false;

    [MaxLength(200, ErrorMessage = "QR code cannot exceed 200 characters.")]
    public string? QRCode { get; set; }

    public Guid? ReservationId { get; set; }
    public Reservation? Reservation { get; set; }

    [Required(ErrorMessage = "EventId is required.")]
    public Guid EventId { get; set; }
    public Event? Event { get; set; }
}
