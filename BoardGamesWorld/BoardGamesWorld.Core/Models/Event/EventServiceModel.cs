using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Infrastructure.Data.Models;

namespace BoardGamesWorld.Core.Models.Event
{
    public class EventServiceModel : IEventServiceModel
    {
        public int Id { get; set; }
        public string OrganizerName { get; set; } = null!;
        public int ThemeId { get; set; }
        public int OrganizerId { get; set; }
        public int BoardGameId { get; set; }
        public string Start { get; set; } = null!;
        public string End { get; set; } = null!;
        public int RequiredParticipants { get; set; }
    }
}
