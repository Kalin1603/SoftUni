using Eventures.Common;
using Eventures.Data;
using Eventures.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Middleware
{
    public static class SeedIdentitiesMiddleware
    {
        public static IApplicationBuilder UseDatabaseSeedWithIdentities(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var roles = new[]
                    {
                            GlobalConstants.ADMIN_ROLE,
                            GlobalConstants.USER_ROLE,
                        };

                    foreach (var role in roles)
                    {
                        bool roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole { Name = role });
                        }
                    }

                    var adminRole = GlobalConstants.ADMIN_ROLE;
                    var adminEmail = "admin@gmail.com";
                    var ucn = "56412566";

                    var adminUser = new User
                    {
                        FirstName = adminRole,
                        LastName = adminRole,
                        Email = adminEmail,
                        UserName = adminRole,
                        Ucn = ucn,
                    };

                    await userManager.CreateAsync(adminUser, "Admin");

                    await userManager.AddToRoleAsync(adminUser, adminRole);

                })
                .Wait();
            }

            return app;
        }
    }
}
