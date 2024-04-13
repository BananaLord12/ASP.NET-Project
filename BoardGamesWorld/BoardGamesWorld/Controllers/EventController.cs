using BoardGamesWorld.Attribute;
using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Event;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGamesWorld.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEvent eventService;

        public EventController(IEvent _eventService)
        {
            eventService = _eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.AllEventsAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if((await eventService.ExistsAsync(id))== false) 
            {
                return RedirectToAction(nameof(All));
            }
            var model = await eventService.EventDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [MustBeAnOrganizer]
        public async Task<IActionResult> Add()
        {
            var model = new EModel()
            {
                ThemeBoardGames = await eventService.AllBoardGamesNamesAsync(),
                ThemeCategories = await eventService.AllThemeCategoriesAsync(),
                OrganizerName = await eventService.GetUserNameById(User.Id()),
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAnOrganizer]
        public async Task<IActionResult> Add(EModel model)
        {
            if((await eventService.ThemeExistsAsync(model.ThemeId) == false))
            {
                ModelState.AddModelError(nameof(model.ThemeId), "Theme does not exists");
            }

            if ((await eventService.BoardGameNameExistsAsync(model.BoardGameId) == false))
            {
                ModelState.AddModelError(nameof(model.BoardGameId), "Board Game does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.ThemeCategories = await eventService.AllThemeCategoriesAsync();
                model.ThemeBoardGames = await eventService.AllBoardGamesNamesAsync();

                return View(model);
            }

            int id = await eventService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpGet]

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
