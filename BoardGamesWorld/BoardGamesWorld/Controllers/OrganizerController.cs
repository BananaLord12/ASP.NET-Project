using BoardGamesWorld.Attribute;
using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Organizer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BoardGamesWorld.Core.Constants.MessageConstants;

namespace BoardGamesWorld.Controllers
{
    public class OrganizerController : BaseController
    {
        private readonly IOrganizerService organizerService;

        public OrganizerController(IOrganizerService _organizerService)
        {
            organizerService = _organizerService;
        }

        [HttpGet]
        [NotAnOrganizer]
        public IActionResult Become()
        {
            var model = new BecomeOrganizerFormModel();
            return View(model);
        }

        [HttpPost]
        [NotAnOrganizer]
        public async Task<IActionResult> Become(BecomeOrganizerFormModel model)
        {
            if(await organizerService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await organizerService.CreateAsync(User.Id(), model.Name, model.PhoneNumber);

            return RedirectToAction(nameof(BoardGameController.All), "BoardGame");
        }
    }
}
