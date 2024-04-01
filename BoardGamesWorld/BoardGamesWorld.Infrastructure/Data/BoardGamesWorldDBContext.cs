using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesWorld.Infrastructure.Data
{
    public class BoardGamesWorldDBContext : IdentityDbContext
    {
        protected BoardGamesWorldDBContext(DbContextOptions<BoardGamesWorldDBContext> options) :
            base(options)
        {
        }
    }
}
