using BoardGamesWorld.Core.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.Admin
{
    public class JoinedEventsViewModel
    {
        public IEnumerable<EventAllViewModel> JoinedEvents { get; set; } = new List<EventAllViewModel>();
    }
}
