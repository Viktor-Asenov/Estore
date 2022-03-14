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
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022CC2B301_922_14?$SFCC_L$" },
                            },
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets & Coats",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EO2G325_400_10?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Jeans",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022CC2B302_903_10?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Shirts",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EO2F311_345_19?$SFCC_L$" },
                                    },
                                },
                            },
                        },
                        new()
                        {
                            Name = "Shoes",
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W308_285_34?$SFCC_L$" },
                            },
                        },
                        new()
                        {
                            Name = "Accessories",
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/111EA2S304_001_34?$SFCC_L$" },
                            },
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Belts",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EA2S303_001_37?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Sunglasses",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/40046S_543_37?$SFCC_L$" },
                                    },
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
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032CC1B308_270_14?$SFCC_L$" },
                            },
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets & Coats",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022CC1G303_275_10?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Jeans",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991CC1B327_902_10?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Dresses",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EO1E347_113_10?$SFCC_L$" },
                                    },
                                },
                            },
                        },
                        new()
                        {
                            Name = "Shoes",
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/071EK1W310_295_34?$SFCC_L$" },
                            },
                        },
                        new()
                        {
                            Name = "Accessories",
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EA1V303_660_34?$SFCC_L$" },
                            },
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Sunglasses",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39078PS_545_37?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Bags",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EA1O307_400_37?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Scarves",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EA1Q303_410_37?$SFCC_L$" },
                                    },
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
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://s3.ap-south-1.amazonaws.com/tcsonline-live/catalog/category/land-boys_2.jpg" },
                            },
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922064201_001_27?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Jeans",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230142901_922_25?$SFCC_L$" },
                                    },
                                },
                            },
                        },
                        new()
                        {
                            Name = "Girls",
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://s3.ap-south-1.amazonaws.com/tcsonline-live/catalog/category/land-girls_2.jpg" },
                            },
                            SubCategories = new List<Category>
                            {
                                new()
                                {
                                    Name = "Jackets",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230254202_361_25?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Jeans",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902032902_901_27?$SFCC_L$" },
                                    },
                                },
                                new()
                                {
                                    Name = "Dresses",
                                    Images = new List<Image>
                                    {
                                        new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7121053101_551_27?$SFCC_L$" },
                                    },
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
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70833D_101_35?$SFCC_L$"},
                            },
                        },
                        new()
                        {
                            Name = "Bathroom",
                            Images = new List<Image>
                            {
                                new() { RemoteUrl = "https://esprit.scene7.com/is/image/esprit/18185B_790_14?$SFCC_L$"},
                            },
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
