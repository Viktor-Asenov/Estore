namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;

    public class HomeProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any(p => p.Category.ParentCategory.Name == "Home"))
            {
                return;
            }

            // ########## PRODUCT TAGS ##########
            var sustainableTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Sustainable");

            // ########## BATHROOM CATEGORY ##########
            var bathroomCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Bathroom");

            var bathroom = new List<Product>
            {
                new()
                {
                    Name = "Suede bathrobe made of 100% cotton",
                    Price = 60,
                    Description = "DAY bathrobe - an all-rounder with nautical stripe details: Bathrobe made of high-quality cotton velours.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = bathroomCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/17382B_740_20?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Suede bathrobe made of 100% cotton",
                    Price = 65,
                    Description = "This bathrobe made of high-quality cotton velours is perfect for getting cosy.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = bathroomCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/17378B_740_20?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Ribbed-effect bathrobe",
                    Price = 76,
                    Description = "This ribbed-effect bathrobe is super soft and an absolute, homewear must-have.",
                    Discount = 30,
                    ItemApplyDiscount = 3,
                    CategoryId = bathroomCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/18710B_438_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/18710B_438_11?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Towelling",
                    Price = 26,
                    Description = "Outer fabric: 100% Cotton.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = bathroomCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/18716B_350_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/18716B_350_35?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Towel",
                    Price = 10,
                    Description = "Outer fabric: 85% Cotton, 15% Lyocell.",
                    Discount = 25,
                    ItemApplyDiscount = 4,
                    CategoryId = bathroomCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/17520B_790_33?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/17520B_790_35?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "100% cotton hand towel",
                    Price = 15,
                    Description = "BOX MELANGE towel - the high-quality towelling fabric made of 100% cotton is not only natural but also sensationally soft to the touch and extremely absorbent.",
                    Discount = 10,
                    ItemApplyDiscount = 4,
                    CategoryId = bathroomCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/17628B_488_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/17628B_488_36?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(bathroom);

            // ########## LIVING CATEGORY ##########
            var livingCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Living");

            var living = new List<Product>
            {
                new()
                {
                    Name = "Curtain made of woven fabric",
                    Price = 46,
                    Description = "Outer fabric: 100% Polyester.",
                    Discount = 15,
                    ItemApplyDiscount = 4,
                    CategoryId = livingCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70460OS_040_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70460OS_040_36?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Duetto reversible curtain",
                    Price = 40,
                    Description = "Elegant and contemporary: shimmering curtain in a great two-tone, trendy colour combination with a reversible option.",
                    Discount = 30,
                    ItemApplyDiscount = 3,
                    CategoryId = livingCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/ES1047_010_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/ES1047_010_36?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Eyelet curtains with a leaf pattern",
                    Price = 45,
                    Description = "These curtains with a leaf pattern bring a touch of natural charm to your home.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = livingCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70886OS_030_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70886OS_030_34?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Cushion cover with a woven pattern",
                    Price = 20,
                    Description = "Make a statement in your interior with this cushion cover.",
                    Discount = 10,
                    ItemApplyDiscount = 4,
                    CategoryId = livingCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/50807KH_010_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/50807KH_010_36?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Cushions deco",
                    Price = 22,
                    Description = "Outer fabric: 100% Polyester.",
                    Discount = 10,
                    ItemApplyDiscount = 4,
                    CategoryId = livingCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70930KH_075_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70930KH_075_34?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Cushion",
                    Price = 25,
                    Description = "Outer fabric: 100% Polyester.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = livingCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70941KH_100_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/70941KH_100_34?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(living);
            await dbContext.SaveChangesAsync();
        }
    }
}
