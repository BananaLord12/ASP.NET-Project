using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.Event
{
    public class EPShortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string OrganizerName { get; set; } = string.Empty;
        public int ThemeId { get; set; }
        public string OrganizerId { get; set; } = string.Empty;
        public int BoardGameId { get; set; }
        public string Start { get; set; } = string.Empty;
        public string End { get; set; } = string.Empty;
        public int RequiredParticipants { get; set; }
    }
}
