using BoardGamesWorld.Core.Costants;
using Microsoft.AspNetCore.Mvc;
using BoardGamesWorld.Core.Contacts;
using BoardGamesWorld.Core.Models.Admin;
using System.Security.Claims;

namespace BoardGamesWorld.Areas.Admin.Controllers
{
    public class EventController : AdminBaseController
    {
        private readonly IEvent _eventService;
        private readonly IOrganizerService _organizerService;

        public EventController(IEvent eventService, IOrganizerService organizerService)
        {
            _eventService = eventService;
            _organizerService = organizerService;
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            int organizerId = await _organizerService.GetOrganizerIdAsync(userId) ?? 0;


            var myEvents = new MyEventsViewModel()
            {
                AddedEvents = await _eventService.GetEventsByOrganizerId(organizerId)
            };


            return View(myEvents);
        }
    }
}
