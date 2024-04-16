using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Costants
{
    public interface IOrganizerService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

        Task CreateAsync(string userId, string name, string phoneNumber);

        Task<int?> GetOrganizerIdAsync(string userId);

        Task<string> GetPhoneNumberFromUserId(string userId);
    }
}
