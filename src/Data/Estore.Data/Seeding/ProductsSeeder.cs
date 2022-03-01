namespace Estore.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;

    internal class ProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any())
            {
                return;
            }

            await dbContext.Products.AddAsync(new Product { });
        }
    }
}
