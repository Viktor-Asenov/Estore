namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;

    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>()
            {
                new()
                {
                    Name = "Men",
                    SubCategories = new List<Category>()
                    {
                        new()
                        {
                            Name = "Clothes",
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets & Coats",
                                },
                                new()
                                {
                                    Name = "Jeans",
                                },
                                new()
                                {
                                    Name = "Shirts",
                                },
                            },
                        },
                        new()
                        {
                            Name = "Shoes",
                        },
                        new()
                        {
                            Name = "Accessories",
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Belts",
                                },
                                new()
                                {
                                    Name = "Sunglasses",
                                },
                            },
                        },
                    },
                },
                new()
                {
                    Name = "Women",
                    SubCategories = new List<Category>()
                    {
                        new()
                        {
                            Name = "Clothes",
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets & Coats",
                                },
                                new()
                                {
                                    Name = "Jeans",
                                },
                                new()
                                {
                                    Name = "Dresses",
                                },
                            },
                        },
                        new()
                        {
                            Name = "Shoes",
                        },
                        new()
                        {
                            Name = "Accessories",
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Sunglasses",
                                },
                                new()
                                {
                                    Name = "Bags",
                                },
                                new()
                                {
                                    Name = "Scarves",
                                },
                            },
                        },
                    },
                },
                new()
                {
                    Name = "Kids",
                    SubCategories = new List<Category>()
                    {
                        new()
                        {
                            Name = "Boys",
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets",
                                },
                                new()
                                {
                                    Name = "Jeans",
                                },
                                new()
                                {
                                    Name = "Shirts",
                                },
                            },
                        },
                        new()
                        {
                            Name = "Girls",
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets",
                                },
                                new()
                                {
                                    Name = "Jeans",
                                },
                                new()
                                {
                                    Name = "Dresses",
                                },
                            },
                        },
                    },
                },
                new()
                {
                    Name = "Home",
                    SubCategories = new List<Category>()
                    {
                        new()
                        {
                            Name = "Living",
                        },
                        new()
                        {
                            Name = "Bathroom",
                        },
                    },
                },
                new()
                {
                    Name = "Sale",
                },
            };

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}
