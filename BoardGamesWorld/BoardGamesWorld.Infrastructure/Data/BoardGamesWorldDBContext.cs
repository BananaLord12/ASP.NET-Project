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
    }
}
