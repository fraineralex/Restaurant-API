using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Infrastructure.Identity.Entities;
using System.Threading.Tasks;
using RestaurantAPI.Core.Application.Enums;
namespace RestaurantAPI.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Waiter.ToString()));
        }
    }
}
