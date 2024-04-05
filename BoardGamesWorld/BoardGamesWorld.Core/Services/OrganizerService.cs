using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Infrastructure.Data.Common;
using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Services
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IRepository repo;

        public OrganizerService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task CreateAsync(string userId, string name, string phoneNumber)
        {
            await repo.AddAsync(new Organizer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                Name = name,
            });

            await repo.SaveChangedAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repo.AllReadOnly<Organizer>()
                .AnyAsync(o => o.UserId== userId);
        }

        public async Task<int?> GetOrganizerIdAsync(string userId)
        {
            return (await repo.AllReadOnly<Organizer>()
                .FirstOrDefaultAsync(o => o.UserId== userId))?.Id;
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repo.AllReadOnly<Organizer>()
                .AnyAsync(o => o.PhoneNumber== phoneNumber);
        }
    }
}
