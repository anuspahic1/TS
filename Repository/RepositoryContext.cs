using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RewardConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }

        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<Reward>? Rewards { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }

    }
}
