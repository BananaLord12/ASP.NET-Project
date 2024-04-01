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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[] { data.Card, data.Cooperative, data.DeckBuilding, data.Adventure, data.Dice, data.Legacy ,data.Puzzle, data.RealTime, data.StoryTelling, data.Trains, data.Word, data.WorkerPlacement });
        }
    }
}
