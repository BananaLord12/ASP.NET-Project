using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Home;
using BoardGamesWorld.Core.Services.BoardGames;
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

        public async Task<BGQueryServiceModel> All(string? category = null,
            string? searchTerm = null,
            BoardGameSorting sorting = BoardGameSorting.Newest,
            int currentPage = 1,
            int bgPerPage = 1)
        {
            var result = new BGQueryServiceModel();
            var boardGames = repository.AllReadOnly<BoardGame>();

            if(string.IsNullOrEmpty(category) == false )
            {
                boardGames = boardGames
                    .Where(h => h.Category.Name == category);
            }

            if(string.IsNullOrEmpty(searchTerm) == false )
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                boardGames = boardGames
                    .Where(h => EF.Functions.Like(h.Name.ToLower(), searchTerm));
            }

            boardGames = sorting switch
            {
                BoardGameSorting.Price => boardGames
                    .OrderBy(h => h.Price),
                _ => boardGames.OrderByDescending(h => h.Id)
            };

            result.BoardGames = await boardGames
                .Skip((currentPage - 1) * bgPerPage)
                .Take(bgPerPage)
                .Select(h => new BoardGameServiceModel()
                {
                    Id= h.Id,
                    Name= h.Name,
                    ImageUrl= h.ImageUrl,
                    Price= h.Price,
                }).ToListAsync();

            result.TotalBoardGamesCount = await boardGames.CountAsync();

            return result;
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

        public async Task<IEnumerable<BoardGameCategoryModel>> AllCategories()
        {
            return await repository.AllReadOnly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new BoardGameCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<BoardGamesDetailsServiceModel> BoardGameDetailsById(int id)
        {
            return await repository.AllReadOnly<BoardGame>()
                .Where(b => b.Id == id)
                .Select(b => new BoardGamesDetailsServiceModel()
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Name = b.Name,
                    Description = b.Description,
                    Price = b.Price,
                    Category = b.Category.Name
                }).FirstAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadOnly<BoardGame>()
                .AnyAsync(b => b.Id== id);
        }

        public async Task<IEnumerable<BoardGameModel>> LastThreeBoardGamesAsync()
        {
            return await repository
                .AllReadOnly<BoardGame>()
                .OrderByDescending(b => b.Id)
                .Take(3)
                .Select(b => new BoardGameModel()
                {
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Name = b.Name
                })
                .ToListAsync();
        }
    }
}
