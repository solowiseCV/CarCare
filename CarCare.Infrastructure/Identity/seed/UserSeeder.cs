using CarCare.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CarCare.Infrastructure.Identity.Seeds
{
    public static class UserSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByEmailAsync("admin@carcare.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@carcare.com",
                    Name = "Admin User",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
