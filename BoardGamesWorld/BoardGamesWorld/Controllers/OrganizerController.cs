using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWorld.Controllers
{
    public class OrganizerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
