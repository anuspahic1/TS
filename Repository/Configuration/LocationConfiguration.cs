using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location
                {
                    Id = Guid.Parse("f1000000-0000-0000-0000-000000000001"),
                    Name = "Zetra Sarajevo",
                    Address = "Alipašina bb",
                    GeoLatitude = 43.8662,
                    GeoLongitude = 18.4131
                },
                new Location
                {
                    Id = Guid.Parse("f2000000-0000-0000-0000-000000000002"),
                    Name = "Skenderija Arena",
                    Address = "Terezija bb",
                    GeoLatitude = 43.8564,
                    GeoLongitude = 18.4130
                }
            );
        }
    }
}
