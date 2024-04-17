using BoardGamesWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorldUnitTests.Mocks
{
    public static class DatabaseMock
    {
        public static BoardGameWDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<BoardGameWDbContext>()
                    .UseInMemoryDatabase("BoardGamesInMemoryDb"
                    +DateTime.Now.Ticks.ToString())
                    .Options;

                return new BoardGameWDbContext(dbContextOptions);
            }
        }
    }
}
