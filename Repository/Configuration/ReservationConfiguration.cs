using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(t => t.TotalPrice).HasPrecision(18, 2);

            builder.HasData(
                new Reservation
                {
                    Id = Guid.Parse("d1000000-0000-0000-0000-000000000001"),
                    CreatedAt = new DateTime(2026, 1, 1),
                    TotalPrice = 50.00m,
                    UserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    EventId = Guid.Parse("e1000000-0000-0000-0000-000000000001")
                }
            );
        }
    }
}
