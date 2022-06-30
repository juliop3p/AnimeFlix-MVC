using AnimeFlix.App.Data;
using AnimeFlix.App.Identity;
using AnimeFlix.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.App.Configurations
{
    public static class MigrationsConfig
    {
        public async static Task Migrate(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = serviceProvider.GetRequiredService<AnimeFlixContext>();
                await context.Database.MigrateAsync();
                // await StoreContextSeed.SeedAsync(context, loggerFactory);

                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var identityContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                await identityContext.Database.MigrateAsync();
                // await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during migration");
            }
        }
    }
}