namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Common;
    using Estore.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (userManager.Users.Any(u => u.Email == "viktor@asenov.com") ||
                userManager.Users.Any(u => u.Email == "pesho@sample.com") ||
                !await roleManager.RoleExistsAsync(GlobalConstants.AdministratorRoleName))
            {
                return;
            }

            var adminCartId = this.GetCartIdAsync(dbContext);

            var admin = new ApplicationUser
            {
                UserName = "Viktor",
                NormalizedUserName = "VIKTOR",
                Email = "viktor@asenov.com",
                NormalizedEmail = "VIKTOR@ASENOV.COM",
                EmailConfirmed = true,
                Gender = GlobalConstants.Male,
                CartId = await adminCartId,
                CreatedOn = DateTime.UtcNow,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                IsDeleted = false,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
            };

            var userCartId = this.GetCartIdAsync(dbContext);

            var user = new ApplicationUser
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@sample.com",
                NormalizedEmail = "PESHO@SAMPLE.COM",
                EmailConfirmed = true,
                CreatedOn = DateTime.UtcNow,
                Gender = GlobalConstants.Male,
                CartId = await userCartId,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                IsDeleted = false,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
            };

            await userManager.CreateAsync(admin, "123456");
            await userManager.CreateAsync(user, "123456");
            await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
        }

        private async Task<string> GetCartIdAsync(ApplicationDbContext dbContext)
        {
            var cart = new Cart { };

            await dbContext.Carts.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            return cart.Id;
        }
    }
}
