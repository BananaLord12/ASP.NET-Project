using BoardGamesWorld.Core.Models.BoardGame;
using BoardGamesWorld.Core.Models.Home;
using BoardGamesWorld.Core.Services.BoardGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Costants
{
    public interface IBoardGameService
    {
        Task<IEnumerable<BoardGameModel>> LastThreeBoardGamesAsync();

        Task<IEnumerable<BoardGamesAllServiceModel>> AllBoardGamesAsync();

        Task<BGQueryServiceModel> All(
            string? category = null,
            string? searchTerm = null,
            BoardGameSorting sorting = BoardGameSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<BoardGameCategoryModel>> AllCategories();

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<BoardGamesDetailsServiceModel> BoardGameDetailsById(int id);

        Task<bool> Exists(int id);

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(BGModel model);

        Task Edit(int bgId, BGModel model);

        Task Delete(int bgId);

        Task<int> GetHouseCategoryId(int bgId);
    }
}
