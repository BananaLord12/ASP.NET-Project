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

namespace BoardGamesWorld.Core.Services
{
    public class EventService : IEvent
    {
        private readonly IRepository repository;

        private readonly ILogger logger;

        public EventService(IRepository _repository, ILogger<EventService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }
        public async Task<IEnumerable<EventAllViewModel>> AllEventsAsync()
        {
            return await repository
                .AllReadOnly<Event>()
                .OrderBy(e => e.Id)
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    OrganizerName = e.OrganizerName,
                    Theme = e.Theme.Name,
                    OrganizerId = e.Organizer.UserId,
                    BoardGame = e.BoardGame.Name,
                    Start = e.Start.ToString(),
                    End = e.End.ToString(),
                    RequiredParticipants = e.RequiredParticipants,
                }).ToListAsync();
        }
    }
}
