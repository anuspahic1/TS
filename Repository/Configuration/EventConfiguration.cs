using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
            new Event
            {
                Id = Guid.Parse("e1000000-0000-0000-0000-000000000001"),
                Name = "Arctic Monkeys World Tour",
                Description = "A night of indie rock excellence in the heart of Sarajevo.",
                CreatedAt = new DateTime(2025, 12, 1),
                EventDate = new DateTime(2026, 6, 15, 20, 0, 0),
                LocationId = Guid.Parse("f1000000-0000-0000-0000-000000000001"),
                CreatorId = Guid.Parse("c1000000-0000-0000-0000-000000000001")
                ,
                Capacity = 5000
            },
            new Event
            {
                Id = Guid.Parse("e2000000-0000-0000-0000-000000000002"),
                Name = "Tech Conference 2026",
                Description = "Join the biggest regional gathering of IT experts and innovators.",
                CreatedAt = new DateTime(2025, 12, 1),
                EventDate = new DateTime(2026, 9, 20, 09, 0, 0),
                LocationId = Guid.Parse("f2000000-0000-0000-0000-000000000002"),
                CreatorId = Guid.Parse("c2000000-0000-0000-0000-000000000002")
                ,
                Capacity = 1200
            },
            new Event
            {
                Id = Guid.Parse("e3000000-0000-0000-0000-000000000003"),
                Name = "The Nutcracker Ballet",
                Description = "A classic festive performance by the Sarajevo Philharmonic Orchestra.",
                CreatedAt = new DateTime(2025, 12, 1),
                EventDate = new DateTime(2026, 12, 24, 19, 30, 0),
                LocationId = Guid.Parse("f3000000-0000-0000-0000-000000000003"),
                CreatorId = Guid.Parse("c3000000-0000-0000-0000-000000000003")
                ,
                Capacity = 800
            }
        );
        }
    }
}
