using AnimeFlix.App.Identity;
using Microsoft.AspNetCore.Identity;

namespace AnimeFlix.App.Configurations
{
    public static class UsersConfig
    {
        public static async Task CreateRoles(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roleNames = { "Admin", "User" };
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during roles creation");
            }
        }

        public static async Task CreatePowerUser(IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                var poweruser = new ApplicationUser
                {
                    UserName = configuration["UserEmail"],
                    Email = configuration["UserEmail"],
                };

                string userPWD = configuration["UserPassword"];

                var _user = await UserManager.FindByEmailAsync(configuration["AdminUserEmail"]);

                if (_user == null)
                {
                    var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                    if (createPowerUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(poweruser, "Admin");

                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during roles creation");
            }

        }
    }
}