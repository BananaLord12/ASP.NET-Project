using BoardGamesWorld.Infrastructure.Data.Models;
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

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Theme> Themes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<BoardGame>()
                .HasOne(b => b.Category)
                .WithMany(c => c.BoardGames)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasOne(e => e.Theme)
                .WithMany(t => t.Events)
                .HasForeignKey(e => e.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasOne(e => e.BoardGame)
                .WithMany(b => b.Events)
                .HasForeignKey(e => e.BoardGameId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
