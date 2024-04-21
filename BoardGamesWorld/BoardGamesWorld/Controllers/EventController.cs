using BoardGamesWorld.Attribute;
using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Event;
using BoardGamesWorld.Core.Models.EventParticipant;
using BoardGamesWorld.Core.Services;
using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGamesWorld.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEvent eventService;
        private readonly IEventParticipants epService;
        private readonly IOrganizerService organizerService;

        public EventController(IEvent _eventService, IEventParticipants _epService, IOrganizerService _organizerService)
        {
            eventService = _eventService;
            epService= _epService;
            organizerService = _organizerService;
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
        public async Task<IActionResult> Edit(int id)
        {
            if((await eventService.ExistsAsync(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            var ev = await eventService.EventDetailsByIdAsync(id);
            var ThemeId = await eventService.GetEventThemeIdAsync(id);
            var bgId = await eventService.GetEventBoardGameIdAsync(id);

            var model = new EModel()
            {
                Id = ev.Id,
                Name = ev.Name,
                Description = ev.Description,
                OrganizerName = ev.OrganizerName,
                ThemeId = ThemeId,
                ThemeCategories = await eventService.AllThemeCategoriesAsync(),
                BoardGameId = bgId,
                ThemeBoardGames = await eventService.AllBoardGamesNamesAsync(),
                Start = ev.Start,
                End = ev.End,
                RequiredParticipants = ev.RequiredParticipants,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await eventService.ExistsAsync(model.Id)) == false)
            {
                ModelState.AddModelError("", "Event does not exist");
                model.ThemeCategories = await eventService.AllThemeCategoriesAsync();
                model.ThemeBoardGames = await eventService.AllBoardGamesNamesAsync();

                return View(model);
            }

            if ((await eventService.ThemeExistsAsync(model.ThemeId)) == false)
            {
                ModelState.AddModelError("", "Theme does not exist");
                model.ThemeCategories = await eventService.AllThemeCategoriesAsync();
                model.ThemeBoardGames = await eventService.AllBoardGamesNamesAsync();

                return View(model);
            }

            if ((await eventService.BoardGameNameExistsAsync(model.BoardGameId)) == false)
            {
                ModelState.AddModelError("", "Board Game does not exist");
                model.ThemeCategories = await eventService.AllThemeCategoriesAsync();
                model.ThemeBoardGames = await eventService.AllBoardGamesNamesAsync();

                return View(model);
            }

            await eventService.EditAsync(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            string userId = GetUserId();

            if((await epService.IsUserAlreadyInTheSameOneAsync(userId, id)) == true)
            {
                ModelState.AddModelError("", "User cannot join the same event");
                return RedirectToAction(nameof(All));
            }

            var model = new EventParticipantModel()
            {
                EventId = id,
                ParticipantId = userId
            };

            await epService.JoinAsync(model);

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userid = GetUserId();

            if (User.isAdmin())
            {
                return RedirectToAction("Mine", "Event", new { area = "Admin" });
            }

            var model = await epService.AllEventsForUser(userid);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if((await eventService.ExistsAsync(id)) == false) 
            {
                return RedirectToAction(nameof(All));
            }

            var ev = await eventService.EventDetailsByIdAsync(id);

            var model = new EventRemovalModel()
            {
                Name = ev.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EventRemovalModel model)
        {
            if ((await eventService.ExistsAsync(id))== false)
            {
                return RedirectToAction(nameof(All));
            }

            var participants = epService.AllParticipantsInEvent(id).Result;

            foreach(var participant in participants)
            {
                var ep = new EventParticipant()
                {
                    EventId = participant.EventId,
                    ParticipantId = participant.Id,
                };

                await epService.LeaveAsync(ep);
            }

            await eventService.DeleteAsync(id);

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if(await eventService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var ep = new EventParticipant()
            {
                EventId = id,
                ParticipantId = GetUserId()
            };

            //var participant = epService.FirstParticipantInEvent(id, GetUserId());

            await epService.LeaveAsync(ep);

            return RedirectToAction(nameof(Joined));
        }

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
