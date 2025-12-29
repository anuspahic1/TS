using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
   public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasData(
            new Location {
                Id = Guid.Parse("f1000000-0000-0000-0000-000000000001"),
                Name = "Zetra Olympic Hall",
                Address = "Alipašina bb, Sarajevo",
                GeoLatitude = 43.8662, GeoLongitude = 18.4131
            },
            new Location {
                Id = Guid.Parse("f2000000-0000-0000-0000-000000000002"),
                Name = "Skenderija Plateau",
                Address = "Terezija bb, Sarajevo",
                GeoLatitude = 43.8564, GeoLongitude = 18.4130
            },
            new Location {
                Id = Guid.Parse("f3000000-0000-0000-0000-000000000003"),
                Name = "National Theater Sarajevo",
                Address = "Obala Kulina bana 9",
                GeoLatitude = 43.8575, GeoLongitude = 18.4206
            }
        );
    }
}
}
