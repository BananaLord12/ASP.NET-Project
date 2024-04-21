using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Admin;
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

        public async Task<IEnumerable<ThemeBoardGamesModel>> AllBoardGamesNamesAsync()
        {
            return await repository
                .AllReadOnly<BoardGame>()
                .OrderBy(b => b.Name)
                .Select(b => new ThemeBoardGamesModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();
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

        public async Task<IEnumerable<ThemeCategoryModel>> AllThemeCategoriesAsync()
        {
            return await repository
                .AllReadOnly<Theme>()
                .OrderBy(t => t.Name)
                .Select(t => new ThemeCategoryModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> BoardGameNameExistsAsync(int bgId)
        {
            return await repository.AllReadOnly<BoardGame>()
                    .AnyAsync(bg => bg.Id == bgId);
        }

        public async Task<int> CreateAsync(EModel model)
        {
            var ev = new Event()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                OrganizerName = model.OrganizerName,
                ThemeId = model.ThemeId,
                OrganizerId = GetOrganiserIdByUserNameAsync(model.OrganizerName).Result,
                BoardGameId = model.BoardGameId,
                Start = model.Start,
                End = model.End,
                RequiredParticipants = model.RequiredParticipants,
            };

            try
            {
                await repository.AddAsync(ev);
                await repository.SaveChangedAsync();
            }catch(Exception ex)
            {
                logger.LogError(nameof(CreateAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return ev.Id;
        }

        public async Task DeleteAsync(int evId)
        {
            try
            {
                await repository.DeleteAsync<Event>(evId);
                await repository.SaveChangedAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(DeleteAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task EditAsync(int evId, EModel model)
        {
            var ev = await repository.GetByIdAsync<Event>(evId);

            ev.Name = model.Name;
            ev.Description = model.Description;
            ev.OrganizerName = model.OrganizerName;
            ev.ThemeId = model.ThemeId;
            ev.BoardGameId = model.BoardGameId;
            ev.Start = model.Start;
            ev.End = model.End;
            ev.RequiredParticipants= model.RequiredParticipants;

            await repository.SaveChangedAsync();
        }

        public async Task<EventModel> EventDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Event>()
                .Where(e => e.Id == id)
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    OrganizerName = e.OrganizerName,
                    OrganizerId = e.Organizer.UserId,
                    ThemeId = e.Theme.Id,
                    BoardGameId = e.BoardGame.Id,
                    Start = e.Start,
                    End = e.End,
                    RequiredParticipants = e.RequiredParticipants,

                }).FirstAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Event>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<int> GetEventBoardGameIdAsync(int evId)
        {
            return (await repository.GetByIdAsync<Event>(evId)).BoardGameId;
        }

        public async Task<IEnumerable<EventAllViewModel>> GetEventsByOrganizerId(int organizerId)
        {
            return await repository.AllReadOnly<Event>()
                .Where(e => e.OrganizerId == organizerId)
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    OrganizerName = e.OrganizerName,
                    ThemeId = e.ThemeId,
                    OrganizerId = e.Organizer.UserId,
                    BoardGameId = e.BoardGameId,
                    Start = e.Start.ToString(),
                    End = e.End.ToString(),
                    RequiredParticipants = e.RequiredParticipants
                }).ToListAsync();
        }

        public async Task<int> GetEventThemeIdAsync(int evId)
        {
            return (await repository.GetByIdAsync<Event>(evId)).ThemeId;
        }

        public async Task<int> GetOrganiserIdByUserNameAsync(string name)
        {
            return await repository.AllReadOnly<Organizer>()
                .Where(o => o.Name == name)
                .Select(o => o.Id)
                .FirstAsync();
        }

        public async Task<string> GetUserNameById(string id)
        {
            return await repository.AllReadOnly<Organizer>()
                .Where(o => o.UserId == id)
                .Select(o => o.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ThemeExistsAsync(int themeId)
        {
            return await repository.AllReadOnly<Theme>()
                .AnyAsync(t => t.Id == themeId);
        }
    }
}
