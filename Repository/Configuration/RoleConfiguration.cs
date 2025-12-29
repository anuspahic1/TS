using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole 
            { 
                Id = "11363362-56e9-438f-85a4-dc5483dcfe30",
                Name = "Administrator", 
                NormalizedName = "ADMINISTRATOR" 
            },
            new IdentityRole 
            { 
                Id = "720daf31-ee16-4555-ab3c-dda08c8c5fb9", 
                Name = "Organizer", 
                NormalizedName = "ORGANIZER" 
            },
            new IdentityRole 
            { 
                Id = "9ee7f699-298b-4614-9783-addcbff01e6b", 
                Name = "User", 
                NormalizedName = "USER" 
            }
        );
    }
}
}
