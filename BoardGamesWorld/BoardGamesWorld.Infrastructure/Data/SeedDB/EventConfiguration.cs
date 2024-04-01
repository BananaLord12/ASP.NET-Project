using Microsoft.EntityFrameworkCore;
using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesWorld.Infrastructure.Data.SeedDB
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasOne(e => e.Theme)
                .WithMany(t => t.Events)
                .HasForeignKey(e => e.ThemeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(e => e.BoardGame)
            //    .WithMany(b => b.Events)
            //    .HasForeignKey(e => e.BoardGameId)
            //    .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Event[] {data.Event});
        }
    }
}
