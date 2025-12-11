using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class AppUser
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required, MaxLength(60)]
        public string FullName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string? BankAccountNumber { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
