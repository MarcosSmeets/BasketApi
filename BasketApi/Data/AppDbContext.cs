using BasketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Possition)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PossitionId);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Country)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.CountryId);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Possition> Possitions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
