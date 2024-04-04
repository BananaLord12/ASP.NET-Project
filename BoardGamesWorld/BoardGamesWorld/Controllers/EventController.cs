using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWorld.Controllers
{
    public class EventController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
