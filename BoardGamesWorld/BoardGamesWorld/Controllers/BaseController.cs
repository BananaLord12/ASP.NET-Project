using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesWorld.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
