using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Event
{
    [Column("EventId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    [MaxLength(100, ErrorMessage = "Event name max length is 100.")]
    public string Name { get; set; }

    [MaxLength(500, ErrorMessage = "Description max length is 500.")]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal MinTicketPrice { get; set; }
    public DateTime EventDate { get; set; }

    [Required(ErrorMessage = "LocationId is required.")]
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }

    public ICollection<Ticket>? Tickets { get; set; }
}
