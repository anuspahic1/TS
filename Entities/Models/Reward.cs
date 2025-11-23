using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Reward
    {
        [Column("RewardId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(AppUser))]
        public Guid UserId { get; set; }
        public AppUser? User { get; set; }

        [Required, MaxLength(150)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string? ImageUrl { get; set; }

        public DateTime GrantedAt { get; set; }
    }
}
