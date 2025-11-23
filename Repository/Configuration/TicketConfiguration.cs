using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(t => t.Price).HasPrecision(18, 2);

            builder.HasData(
                new Ticket
                {
                    Id = Guid.Parse("d1000000-0000-0000-0000-000000000001"),
                    Price = 25.00m,
                    SeatNumber = "A1",
                    IsReserved = true,
                    QRCode = "QR_ABC123",
                    ReservationId = Guid.Parse("d1000000-0000-0000-0000-000000000001"),
                    EventId = Guid.Parse("e1000000-0000-0000-0000-000000000001")
                },
                new Ticket
                {
                    Id = Guid.Parse("d2000000-0000-0000-0000-000000000002"),
                    Price = 25.00m,
                    SeatNumber = "A2",
                    IsReserved = true,
                    QRCode = "QR_DEF456",
                    ReservationId = Guid.Parse("d1000000-0000-0000-0000-000000000001"),
                    EventId = Guid.Parse("e1000000-0000-0000-0000-000000000001")
                }
            );
        }
    }
}
