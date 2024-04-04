using Microsoft.AspNetCore.Mvc;
using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Home;
using BoardGamesWorld.Models;
using Microsoft.AspNetCore.Authorization;
using BoardGamesWorld.Core.Models.BoardGame;

namespace BoardGamesWorld.Controllers
{
    public class BoardGameController : BaseController
    {
        private readonly IBoardGameService boardGameService;
        //private readonly ILogger logger; , ILogger _logger logger = _logger;

        public BoardGameController(IBoardGameService _boardGameService)
        {
            boardGameService = _boardGameService;
            
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> All([FromQuery]AllBoardGamesQueryModel query)
        {
            var result = await boardGameService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllBoardGamesQueryModel.BoardGamesPerPage);

            query.TotalBoardGamesCount = result.TotalBoardGamesCount;
            query.Categories = await boardGameService.AllCategoriesNames();
            query.BoardGames = result.BoardGames;

            return View(query);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if((await boardGameService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await boardGameService.BoardGameDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BGModel()
            {
                BoardGameCategories = await boardGameService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BGModel model)
        {
            if((await boardGameService.CategoryExists(model.CategoryId) == false))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.BoardGameCategories = await boardGameService.AllCategories();

                return View(model);
            }

            int id = await boardGameService.Create(model);

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
