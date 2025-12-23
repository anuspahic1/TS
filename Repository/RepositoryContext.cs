using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RewardConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
           // modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Reward>? Rewards { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }

    }
}
