using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class AppUser
{
    [Column("UserId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Full name is required.")]
    [MaxLength(60, ErrorMessage = "Full name max length is 60.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(30, ErrorMessage = "Bank account number max length is 30.")]
    public string? BankAccountNumber { get; set; }

    public ICollection<Reservation>? Reservations { get; set; }
}
