using BoardGamesWorld.Core.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Costants
{
    public interface IEvent
    {
        Task<IEnumerable<EventAllViewModel>> AllEventsAsync();

        Task<IEnumerable<ThemeCategoryModel>> AllThemeCategoriesAsync();

        Task<IEnumerable<ThemeBoardGamesModel>> AllBoardGamesNamesAsync();

        Task<EventModel> EventDetailsByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<bool> ThemeExistsAsync(int themeId);

        Task<bool> BoardGameNameExistsAsync(int bgId);

        Task<int> CreateAsync(EModel model);

        Task<string> GetUserNameById(string id);

        Task<int> GetOrganiserIdByUserName(string name);

        Task Edit(int evId, EModel model);
    }
}
