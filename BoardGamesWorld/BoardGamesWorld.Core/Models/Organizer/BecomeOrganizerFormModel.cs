using System.ComponentModel.DataAnnotations;
using static BoardGamesWorld.Core.Constants.MessageConstants;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Core.Models.Organizer
{
    public class BecomeOrganizerFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(OrganizerPhoneNumberMaxLength,
    MinimumLength = OrganizerPhoneNumberMinLength,
    ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(OrganizerNameMaxLength,
            MinimumLength = OrganizerNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
    }
}
