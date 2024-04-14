using BoardGamesWorld.Core.Services;
using BoardGamesWorld.Infrastructure.Data.Common;
using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Event;
using BoardGamesWorld.Infrastructure.Data.Common;
using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesWorld.Core.Models.EventParticipant;

namespace BoardGamesWorld.Core.Costants
{
    public interface IEventParticipants
    {
        Task<IEnumerable<EventAllViewModel>> AllEventsForUser(string userid);

        Task<bool> IsUserAlreadyInTheSameOneAsync(string userid, int id);

        Task<int> JoinAsync(EventParticipantModel model);

        Task<IEnumerable<EParticipant>> AllParticipantsInEvent(int evid);

        Task DeleteRangeAsync(IEnumerable<EParticipant> participants);
        Task<EParticipant> FirstParticipantInEvent(int evid, string userid);

        Task LeaveAsync(EventParticipant evid);
    }
}
