using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Infrastructure.Data.Models
{
    [Comment("Event Theme")]
    public class Theme
    {
        [Key]
        [Comment("Theme Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ThemeNameMaxLength)]
        [Comment("Theme Name")]
        public string Name { get; set; } = string.Empty;

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
