using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Notifications;
using AnimeFlix.Business.Services;
using AnimeFlix.Data.Context;
using AnimeFlix.Data.Repository;

namespace AnimeFlix.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AnimeFlixContext>();
            services.AddScoped<IAnimeRepository, AnimeRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();

            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<IAnimeService, AnimeService>();
            services.AddScoped<ISessionService, SessionService>();
            
            return services;
        }
    }
}
