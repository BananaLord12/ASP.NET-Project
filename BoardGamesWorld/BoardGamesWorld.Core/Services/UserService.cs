using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Models.Admin.User;
using BoardGamesWorld.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGamesWorld.Infrastructure.Data.Models;
using System.Runtime.CompilerServices;

namespace BoardGamesWorld.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IOrganizerService organizerService;

        public UserService(IRepository _repository, IOrganizerService organizerService)
        {
            this.repository = _repository;
            this.organizerService = organizerService;
        }

        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            var result = new List<UserServiceModel>();

            return await repository.AllReadOnly<IdentityUser>()
                .OrderBy(u => u.Email)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    PhoneNumber = organizerService.GetPhoneNumberFromUserId(u.Id).Result,
                    IsOrganizer = organizerService.ExistsByIdAsync(u.Id).Result         
                }).ToListAsync();
        }

        public Task<string> UserFullNameAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
