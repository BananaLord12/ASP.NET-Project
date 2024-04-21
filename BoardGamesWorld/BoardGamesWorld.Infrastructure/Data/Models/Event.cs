using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Infrastructure.Data.Models
{
    [Comment("Information for the Event")]
    public class Event
    {
        [Key]
        [Comment("Event Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        [Comment("Event Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescMaxLength)]
        [Comment("Event Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(OrganizerNameMaxLength)]
        [Comment("Organizer's Name")]
        public string OrganizerName { get; set; } = string.Empty;

        [Required]
        [Comment("Theme Identifier")]
        public int ThemeId { get; set; }

        [ForeignKey(nameof(ThemeId))]
        public Theme Theme { get; set; } = null!;

        [Required]
        [Comment("Organizer Identifier")]
        public int OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Organizer Organizer { get; set; } = null!;

        [Required]
        [Comment("Board Game Identifier")]
        public int BoardGameId { get; set; }

        [ForeignKey(nameof(BoardGameId))]
        public BoardGame BoardGame { get; set; } = null!;

        [Required]
        [Comment("Event Start Time")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("Event End Time")]
        public DateTime End { get; set; }

        [Required]
        [Comment("Participants Required")]
        public int RequiredParticipants { get; set; }

        public IList<EventParticipant> Participants { get; set; } = new List<EventParticipant>();

    }
}
