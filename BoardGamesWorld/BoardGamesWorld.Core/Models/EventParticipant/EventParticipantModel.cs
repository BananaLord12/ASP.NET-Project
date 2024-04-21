using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.EventParticipant
{
    public class EventParticipantModel
    {
        public int EventId { get; set; }

        public string ParticipantId { get; set; } = string.Empty;
    }
}
