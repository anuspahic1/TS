using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Price).HasPrecision(18, 2);
        
        var tickets = new List<Ticket>();
        var eventIds = new[] {
            Guid.Parse("e1000000-0000-0000-0000-000000000001"),
            Guid.Parse("e2000000-0000-0000-0000-000000000002"),
            Guid.Parse("e3000000-0000-0000-0000-000000000003")
        };

        foreach (var eventId in eventIds)
        {
            int ticketCounter = 1;
            for (int i = 0; i < 3; i++)
            {
                char row = (char)('A' + i);
                for (int seatNum = 1; seatNum <= 10; seatNum++)
                {
                    tickets.Add(new Ticket
                    {
                        Id = Guid.NewGuid(), 
                        Price = eventId.ToString().Contains("1") ? 55.00m : 25.50m,
                        SeatNumber = $"{row}{seatNum}",
                        IsReserved = false,
                        EventId = eventId
                    });
                }
            }
        }

        builder.HasData(tickets);
    }
}
}
