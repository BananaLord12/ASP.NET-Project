using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.Event
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OrganizerName { get; set; } = string.Empty;
        public int ThemeId { get; set; }
        public string OrganizerId { get; set; } = string.Empty;
        public int BoardGameId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RequiredParticipants { get; set; }
        public IEnumerable<ThemeCategoryModel> ThemeCategories { get; set; } = new List<ThemeCategoryModel>();
        public IEnumerable<ThemeBoardGamesModel> ThemeBoardGames { get; set; } = new List<ThemeBoardGamesModel>();
    }
}
