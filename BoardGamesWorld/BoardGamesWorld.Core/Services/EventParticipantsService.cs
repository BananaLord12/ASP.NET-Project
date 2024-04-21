using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Event;
using BoardGamesWorld.Core.Models.EventParticipant;
using BoardGamesWorld.Infrastructure.Data.Common;
using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Services
{
    public class EventParticipantsService : IEventParticipants
    {
        private readonly IRepository repository;

        private readonly ILogger logger;

        public EventParticipantsService(IRepository _repository, ILogger<EventParticipantsService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        public async Task<IEnumerable<EventAllViewModel>> AllEventsForUser(string userid)
        {
            return await repository
                .AllReadOnly<EventParticipant>()
                .Where(ep => ep.ParticipantId == userid)
                .OrderBy(ep => ep.EventId)
                .Select(ep => new EventAllViewModel()
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Description = ep.Event.Description,
                    OrganizerName = ep.Event.OrganizerName,
                    Theme = ep.Event.Theme.Name,
                    OrganizerId = ep.Event.Organizer.UserId,
                    BoardGame = ep.Event.BoardGame.Name,
                    Start = ep.Event.Start.ToString(),
                    End = ep.Event.End.ToString(),
                    RequiredParticipants = ep.Event.RequiredParticipants,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EParticipant>> AllParticipantsInEvent(int evid)
        {
            return await repository
                .AllReadOnly<EventParticipant>()
                .Where(ep => ep.EventId == evid)
                .Select(ep => new EParticipant()
                {
                    Id = ep.ParticipantId,
                    EventId = ep.EventId                
                })
                .ToListAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<EParticipant> participants)
        {
            try
            {
                await repository.DeleteRangeAsync<EventParticipant>(participants.ToArray());
                await repository.SaveChangedAsync();
            }catch(Exception ex)
            {
                logger.LogError(nameof(DeleteRangeAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task<EParticipant> FirstParticipantInEvent(int evid, string userid)
        {
            return await repository
                .AllReadOnly<EventParticipant>()
                .Where(ep => ep.EventId == evid)
                .Select(ep => new EParticipant()
                {
                    Id = ep.ParticipantId,
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> IsUserAlreadyInTheSameOneAsync(string userid, int id)
        {
            return await repository
                .AllReadOnly<EventParticipant>()
                .AnyAsync(ep => ep.ParticipantId == userid && ep.EventId == id);
        }
        public async Task<int> JoinAsync(EventParticipantModel model)
        {
            var ep = new EventParticipant() 
            {
                EventId= model.EventId,
                ParticipantId = model.ParticipantId,
            };

            try
            {
                await repository.AddAsync(ep);
                await repository.SaveChangedAsync();
            }catch(Exception ex)
            {
                logger.LogError(nameof(JoinAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return ep.EventId;
        }

        public async Task LeaveAsync(EventParticipant ep)
        {
            object[] arr = new object[2] { ep.EventId, ep.ParticipantId };
            try
            {
                await repository.DeleteEntity<EventParticipant>(arr);
                await repository.SaveChangedAsync();
            }catch (Exception ex)
            {
                logger.LogError(nameof(LeaveAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }
    }
}
