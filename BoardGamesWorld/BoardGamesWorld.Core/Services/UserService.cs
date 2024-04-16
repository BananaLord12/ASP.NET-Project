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
            return await repository.AllReadOnly<IdentityUser>()
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email
                }).ToListAsync();
        }

        public Task<string> UserFullNameAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
