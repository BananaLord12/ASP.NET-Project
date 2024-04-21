using BoardGamesWorld.Core.Costants;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWorld.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService users;

        public UserController(IUserService _users)
        {
            users = _users;
        }

        public async Task<IActionResult> All()
        {
            var Users = await users.AllAsync();
            return View(Users);
        }
    }
}
