using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoardGamesWorld.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBoardGameService boardGameService;

        public HomeController(
            ILogger<HomeController> logger,
            IBoardGameService _boardGameService)
        {
            _logger = logger;
            boardGameService= _boardGameService;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var model = await boardGameService.LastThreeBoardGamesAsync();

            return View(model);
        }

        [AllowAnonymous]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}