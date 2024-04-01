using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Infrastructure.Data.SeedDB
{
    internal class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            var data = new SeedData();

            builder.HasData(new Theme[] { data.Animals, data.Campaign, data.CityBuilding, data.Civilization, data.ClassicGames, data.Dungeon, data.Exploration, data.Family, data.Horror, data.Magic, data.ScienceFiction, data.Trivia});
        }
    }
}
