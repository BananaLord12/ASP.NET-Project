using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWorld.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
