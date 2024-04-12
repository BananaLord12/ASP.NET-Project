using BoardGamesWorld.Controllers;
using BoardGamesWorld.Core.Costants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace BoardGamesWorld.Attribute
{
    public class MustBeAnOrganizerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            IOrganizerService? organizerService = context.HttpContext.RequestServices.GetService<IOrganizerService>();

            if (organizerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (organizerService != null
                && organizerService.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(OrganizerController.Become), "Organizer", null);
            }
        }
    }
}
