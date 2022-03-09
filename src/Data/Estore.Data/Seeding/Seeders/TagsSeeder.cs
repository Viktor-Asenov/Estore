namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;

    public class TagsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            var tags = new List<Tag>
            {
                new()
                {
                    Name = "Fashion",
                },
                new()
                {
                    Name = "Leather",
                },
                new()
                {
                    Name = "Sustainable",
                },
                new()
                {
                    Name = "Vegan",
                },
                new()
                {
                    Name = "Recycled",
                },
                new()
                {
                    Name = "Organic",
                },
                new()
                {
                    Name = "Slim",
                },
            };

            await dbContext.Tags.AddRangeAsync(tags);
            await dbContext.SaveChangesAsync();
        }
    }
}
