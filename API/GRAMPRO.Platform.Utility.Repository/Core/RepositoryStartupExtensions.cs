using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Repository.Operations;
using Service.Repository.Authenticate;


using GRAMPRO.Platform.Utility.Model.Authentication;
using Microsoft.AspNetCore.Identity;

namespace GRAMPRO.Platform.Utility.Repository
{
    public static class RepositoryStartupExtensions
    {
        public static IServiceCollection AddCloudscribeCoreRepository(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<ApplicationContext>(ServiceLifetime.Scoped);
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITeamCountRepository, TeamCountRepository>();
            services.AddScoped<IStatusDataRepository, StatusDataRepository>();
            services.AddScoped<ITicketValueDataRepository, TicketValueDataRepository>();
            //For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}