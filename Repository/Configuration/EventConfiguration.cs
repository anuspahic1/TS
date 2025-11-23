using Entities.Models;
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
                    Name = "Rok Koncert",
                    Description = "Najveći rock koncert godine!",
                    Created = new DateTime(2026, 1, 1),
                    LocationId = Guid.Parse("f1000000-0000-0000-0000-000000000001")
                },
                new Event
                {
                    Id = Guid.Parse("e2000000-0000-0000-0000-000000000002"),
                    Name = "Stand-up Večer",
                    Description = "Specijalna komedija večer.",
                    Created = new DateTime(2026,1,1),
                    LocationId = Guid.Parse("f2000000-0000-0000-0000-000000000002")
                }
            );
        }
    }
}
