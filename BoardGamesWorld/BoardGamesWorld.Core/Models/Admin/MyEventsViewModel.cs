using BoardGamesWorld.Core.Models.Event;

namespace BoardGamesWorld.Core.Models.Admin
{
    public class MyEventsViewModel
    {
        public IEnumerable<EventAllViewModel> AddedEvents { get; set; } = new List<EventAllViewModel>();
    }
}
