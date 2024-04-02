using BoardGamesWorld.Infrastructure.Data.Models;
using BoardGamesWorld.Infrastructure.Data.SeedDB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesWorld.Infrastructure.Data
{
    public class BoardGamesWorldDBContext : IdentityDbContext
    {
        public BoardGamesWorldDBContext(DbContextOptions<BoardGamesWorldDBContext> options) :
            base(options)
        {
        }

        public DbSet<BoardGame> BoardGames { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Organizer> Organizers { get; set; } = null!;
        public DbSet<Theme> Themes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OrganizerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ThemeConfiguration());
            builder.ApplyConfiguration(new BoardGameConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
