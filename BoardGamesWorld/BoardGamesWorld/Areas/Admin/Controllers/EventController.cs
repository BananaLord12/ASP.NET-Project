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
        private readonly IEventParticipants epService;

        public EventController(IEvent eventService, IOrganizerService organizerService, IEventParticipants _epService)
        {
            _eventService = eventService;
            _organizerService = organizerService;
            epService = _epService;
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

        public async Task<IActionResult> Joined()
        {

            var userId = User.Id();

            var joinedEvents = new JoinedEventsViewModel()
            {
                JoinedEvents = await epService.AllEventsForUser(userId)
            };

            return View(joinedEvents);
        }
    }
}
