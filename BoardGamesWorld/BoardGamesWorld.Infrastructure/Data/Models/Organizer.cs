using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Infrastructure.Data.Models
{
    [Comment("Event Organizer")]
    public class Organizer
    {
        [Key]
        [Comment("Organizer Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(OrganizerNameMaxLength)]
        [Comment("Organizer Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(OrganizerNameMaxLength)]
        [Comment("Organizer's Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
