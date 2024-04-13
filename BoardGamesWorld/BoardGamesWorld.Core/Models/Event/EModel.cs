using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.Event
{
    public class EModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(EventNameMaxLength,
            MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(EventDescMaxLength,
            MinimumLength = EventDescMinLength)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Organizer's Name")]
        public string OrganizerName { get; set; } = string.Empty;
        [Display(Name = "Theme")]
        public int ThemeId { get; set; }
        [Display(Name = "Board Game Name")]
        public int BoardGameId { get; set; }
        [Required]
        [Display(Name = DateFormat)]
        public DateTime Start { get; set; }
        [Required]
        [Display(Name = DateFormat)]
        public DateTime End { get; set; }
        [Required]
        [Display(Name = "Required Participants")]
        public int RequiredParticipants { get; set; }
    }
}
