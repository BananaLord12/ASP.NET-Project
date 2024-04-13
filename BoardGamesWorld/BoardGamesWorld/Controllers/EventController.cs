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

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
