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
    internal class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
    {
        public void Configure(EntityTypeBuilder<Contributor> builder)
        {
            var data = new SeedData();

            builder.HasData(new Contributor[] { data.Contributer });
        }
    }
}
