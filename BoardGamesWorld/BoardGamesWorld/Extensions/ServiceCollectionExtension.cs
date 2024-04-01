using BoardGamesWorld.Data;
using BoardGamesWorld.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddApplicationDBContext(this IServiceCollection service, IConfiguration config)
        {

            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            service.AddDbContext<BoardGamesWorldDBContext>(options =>
                options.UseSqlServer(connectionString));

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
                })
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            return service;

        }

    }
}
