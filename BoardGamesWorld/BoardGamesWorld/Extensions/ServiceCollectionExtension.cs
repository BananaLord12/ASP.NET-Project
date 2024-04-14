using BoardGamesWorld.Core.Costants;
using BoardGamesWorld.Core.Services;
using BoardGamesWorld.Infrastructure.Data;
using BoardGamesWorld.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IBoardGameService, BoardGamesService>();
            service.AddScoped<IOrganizerService, OrganizerService>();
            service.AddScoped<IEvent, EventService>();
            service.AddScoped<IEventParticipants, EventParticipantsService>();

            return service;
        }

        public static IServiceCollection AddApplicationDBContext(this IServiceCollection service, IConfiguration config)
        {

            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            service.AddDbContext<BoardGameWDbContext>(options =>
                options.UseSqlServer(connectionString));

            service.AddScoped<IRepository, Repository>();

            service.AddDatabaseDeveloperPageExceptionFilter();

            return service;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection service, IConfiguration config)
        {
            service
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit= false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BoardGameWDbContext>();
            return service;

        }

    }
}
