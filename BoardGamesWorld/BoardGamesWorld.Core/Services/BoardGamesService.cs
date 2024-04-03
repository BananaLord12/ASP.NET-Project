using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Home;
using BoardGamesWorld.Infrastructure.Data.Common;
using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesWorld.Core.Services
{
    public class BoardGamesService : IBoardGameService
    {
        private readonly IRepository repository;

        public BoardGamesService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<BoardGamesAllServiceModel>> AllBoardGamesAsync()
        {
            return await repository
                    .AllReadOnly<BoardGame>()
                    .OrderBy(b => b.Id)
                    .Select(b => new BoardGamesAllServiceModel()
                    {
                        Id = b.Id,
                        ImageUrl = b.ImageUrl,
                        Name = b.Name
                    })
                    .ToListAsync();
        }

        public async Task<IEnumerable<BoardGamesIndexServiceModel>> LastThreeBoardGamesAsync()
        {
            return await repository
                .AllReadOnly<BoardGame>()
                .OrderByDescending(b => b.Id)
                .Take(3)
                .Select(b => new BoardGamesIndexServiceModel()
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Name = b.Name
                })
                .ToListAsync();
        }
    }
}
