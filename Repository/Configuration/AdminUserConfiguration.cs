using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class AdminUserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var adminId = "b74ddd14-6340-4840-95c2-db12554843e5";
            var admin = new User
            {
                Id = adminId,
                UserName = "admin@entriox.com",
                NormalizedUserName = "ADMIN@ENTRIOX.COM",
                Email = "admin@entriox.com",
                NormalizedEmail = "ADMIN@ENTRIOX.COM",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Administrator"
            };

            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123!");

            builder.HasData(admin);
        }
    }
}