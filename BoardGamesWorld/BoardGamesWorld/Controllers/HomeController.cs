using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static BoardGamesWorld.Core.Contacts.AdministratorConstants;

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

        public async Task<IActionResult> Index()
        {

            if (User.IsInRole(AdminRole))
            {
                return RedirectToAction("DashBoard", "Home", new { area = "Admin" });
            }

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