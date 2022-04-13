namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;

    internal class WomenProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any(p => p.Category.ParentCategory.ParentCategory.Name == "Women"))
            {
                return;
            }

            // ########## PRODUCT TAGS ##########
            var sustainableTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Sustainable");
            var fashionTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Fashion");
            var recycledTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Recycled");
            var organicTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Organic");
            var slimTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Slim");
            var leatherTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Leather");
            var veganTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Vegan");

            // ########## JACKETS CATEGORY ##########
            var jacketsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jackets" && c.ParentCategory.ParentCategory.Name == "Women");

            var jackets = new List<Product>
            {
                new()
                {
                    Name = "Quilted jacket with a detachable hood, made of recycled material",
                    Price = 90,
                    Description = "This jacket is just the ticket to protect you from wind and rain. It is made entirely of recycled material and features a detachable hood and side hem zips.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EE1G321_295_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EE1G321_295_14?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Coat",
                    Price = 129,
                    Description = "Lining made entirely of recycled material. 2 out of 3 star cold temperature rating: suitable for normal winter weather. Fitted cut",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE1G328_635_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE1G328_635_14?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE1G328_635_16?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Tailored Coat",
                    Price = 130,
                    Description = "Organic cotton: cotton organically cultivated in a controlled setting. 1 out of 3 star cold temperature rating: suitable for milder winter weather. Shoulder and back yokes.",
                    Discount = 30,
                    ItemApplyDiscount = 4,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EO1G324_400_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EO1G324_400_14?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Faux leather biker jacket",
                    Price = 87,
                    Description = "An absolute essential that no wardrobe should be without: biker jacket made of high-quality faux leather with characteristic details.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991CC1G304_001_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991CC1G304_001_14?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = veganTag.Id },
                        new ProductTag { TagId = fashionTag.Id },
                        new ProductTag { TagId = leatherTag.Id },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(jackets);

            // ########## JEANS CATEGORY ##########
            var jeansCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jeans" && c.ParentCategory.ParentCategory.Name == "Women");

            var jeans = new List<Product>
            {
                new()
                {
                    Name = "Stretch jeans containing organic cotton",
                    Price = 59,
                    Description = "An all-time classic, these extra comfy stretch jeans are made of denim with premium organic cotton. Their skinny fit gives them a timeless look.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EE1B322_901_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EE1B322_901_14?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = organicTag.Id },
                        new ProductTag { TagId = slimTag.Id },
                    },
                },
                new()
                {
                    Name = "Jeans",
                    Price = 49,
                    Description = "Organic cotton: cotton organically cultivated in a controlled setting. Waistband with belt loops, a button and zip fly. Slim fit.",
                    Discount = 15,
                    ItemApplyDiscount = 3,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992CC1B308_910_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992CC1B308_910_16?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                        new ProductTag { TagId = organicTag.Id },
                    },
                },
                new()
                {
                    Name = "Jeans",
                    Price = 59,
                    Description = "Organic cotton: cotton organically cultivated in a controlled setting. Waistband with belt loops, a button and zip fly. Slim fit.",
                    Discount = 15,
                    ItemApplyDiscount = 3,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE1B333_903_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE1B333_903_14?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Super stretch jeans made of organic cotton",
                    Price = 49,
                    Description = "Organic cotton: cotton organically cultivated in a controlled setting. Waistband with belt loops, a button and zip fly. Slim fit.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992CC1B307_923_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992CC1B307_923_14?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = organicTag.Id },
                        new ProductTag { TagId = fashionTag.Id },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(jeans);

            // ########## DRESSES CATEGORY ##########
            var dressesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Dresses" && c.ParentCategory.ParentCategory.Name == "Women");

            var dresses = new List<Product>
            {
                new()
                {
                    Name = "Shirt dress made of stretch cotton",
                    Price = 59,
                    Description = "The simple, wide fit makes this shirt dress made of stretch cotton a sporty and elegant all-rounder.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = dressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032EE1E321_400_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032EE1E321_400_14?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Dress with denim-look buttons",
                    Price = 60,
                    Description = "Denim lovers look out! This dress with buttons and a smocked waist can be teamed with both office outfits or off-duty styles.",
                    Discount = 40,
                    ItemApplyDiscount = 3,
                    CategoryId = dressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EF1A340_430_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EF1A340_430_11?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = fashionTag.Id },
                    },
                },
                new()
                {
                    Name = "Dress",
                    Price = 74,
                    Description = "All-over print. Wide round neckline. 3/4 sleeves with button-fastening cuffs. Zip at the back. Straight fit. Mini length.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = dressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992EO1E309_003_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992EO1E309_003_14?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Shirt dress with tie-around belt",
                    Price = 69,
                    Description = "An office classic: striped shirt dress with tie - around belt for a fabulous silhouette.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = dressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032EE1E310_103_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032EE1E310_103_14?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(dresses);

            // ########## SHOES CATEGORY ##########
            var shoesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Shoes" && c.ParentCategory.Name == "Women");

            var shoes = new List<Product>
            {
                new()
                {
                    Name = "Faux leather trainers",
                    Price = 50,
                    Description = "Upper made of authentic faux smooth leather. Flexible, non-slip outsole with a slight tread. Round toe.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W301_100_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W301_100_31?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = veganTag.Id },
                        new ProductTag { TagId = leatherTag.Id },
                    },
                },
                new()
                {
                    Name = "Casual shoes",
                    Price = 59,
                    Description = "Outer material made of authentically grained faux leather. Rounded toe. Twelve-hole lacing. Outsole with profile.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W311_400_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W311_400_31?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Smooth leather Chelsea boots",
                    Price = 110,
                    Description = "Perfect with trousers, skirts or dresses: these high-quality, leather Chelsea boots with a long leg.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/101EK1W326_001_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/101EK1W326_001_31?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = leatherTag.Id },
                        new ProductTag { TagId = fashionTag.Id },
                    },
                },
                new()
                {
                    Name = "Shoes",
                    Price = 43,
                    Description = "Upper made of faux suede. Small block heel.",
                    Discount = 5,
                    ItemApplyDiscount = 2,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W323_040_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W323_040_31?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EK1W323_040_32?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(shoes);

            // ########## SUNGLASSES CATEGORY ##########
            var sunglassesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Sunglasses" && c.ParentCategory.ParentCategory.Name == "Women");

            var sunglasses = new List<Product>
            {
                new()
                {
                    Name = "Sunglasses with transparent frame",
                    Price = 29,
                    Description = "The transparent frames and oversized design give these sunglasses their fashionable look.",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39112S_535_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39112S_535_36?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Sunglasses with patterned temples",
                    Price = 29,
                    Description = "We just love striking patterns! The polka dot and stripe patterns on these trendy sunglasses are absolutely lush.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39019S_538_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39019S_538_36?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Sunglasses with polarised lenses",
                    Price = 54,
                    Description = "These ultra stylish cat eye sunglasses are a must for all women who want to highlight their femininity with gorgeous accessories.",
                    Discount = 25,
                    ItemApplyDiscount = 2,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39106PS_535_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39106PS_535_36?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = fashionTag.Id },
                    },
                },
                new()
                {
                    Name = "Sunglasses",
                    Price = 39,
                    Description = "These ultra stylish cat eye sunglasses are a must for all women who want to highlight their femininity with gorgeous accessories",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39183S_515_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39183S_515_36?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(sunglasses);

            // ########## BAGS CATEGORY ##########
            var bagsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Bags" && c.ParentCategory.ParentCategory.Name == "Women");

            var bags = new List<Product>
            {
                new()
                {
                    Name = "Faux leather hobo bag",
                    Price = 50,
                    Description = "Your everyday essential: Faux leather hobo bag.",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = bagsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1O301_001_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1O301_001_32?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = leatherTag.Id },
                        new ProductTag { TagId = veganTag.Id },
                    },
                },
                new()
                {
                    Name = "Faux leather shoulder bag",
                    Price = 62,
                    Description = "Your everyday essential: Medium sized shoulder bag made of finely grained faux leather.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = bagsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EA1O302_220_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EA1O302_220_37?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = veganTag.Id },
                        new ProductTag { TagId = leatherTag.Id },
                        new ProductTag { TagId = fashionTag.Id },
                    },
                },
                new()
                {
                    Name = "Flapover bag in faux leather",
                    Price = 48,
                    Description = "One bag, two looks: Whether worn as a tote or a casual flap - over bag - this bag is so versatile!",
                    Discount = 30,
                    ItemApplyDiscount = 3,
                    CategoryId = bagsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1O302_001_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1O302_001_32?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = leatherTag.Id },
                        new ProductTag { TagId = veganTag.Id },
                    },
                },
                new()
                {
                    Name = "Vegan: colour block bag",
                    Price = 56,
                    Description = "This shoulder bag in a colour block design creates a fantastic colour accent.",
                    Discount = 10,
                    ItemApplyDiscount = 4,
                    CategoryId = bagsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EA1O307_440_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EA1O307_440_37?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = veganTag.Id },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(bags);

            // ########## SCARVES CATEGORY ##########
            var scarvesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Scarves" && c.ParentCategory.ParentCategory.Name == "Women");

            var scarves = new List<Product>
            {
                new()
                {
                    Name = "Scarf",
                    Price = 25,
                    Description = "Soft woven fabric made of recycled material. With an all-over pattern. Fine fringing on the scarf ends.",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = scarvesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EA1Q301_420_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EA1Q301_420_37?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Fine cotton snood",
                    Price = 20,
                    Description = "BCI (Better Cotton Initiative): promotes the sustainable production of cotton and improved working conditions. Fashionable snood design.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = scarvesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1Q301_345_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1Q301_345_37?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA1Q301_345_36?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Made of cashmere/RWS wool: knitted scarf",
                    Price = 76,
                    Description = "Treat yourself to a touch of luxury: This stylish all - rounder is incredibly soft and cosy thanks to the exquisite cashmere and animal-friendly wool.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = scarvesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/101EA1Q335_001_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/101EA1Q335_001_37?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new ProductTag { TagId = sustainableTag.Id },
                        new ProductTag { TagId = fashionTag.Id },
                    },
                },
                new()
                {
                    Name = "Alpaca/wool blend: fluffy scarf",
                    Price = 75,
                    Description = "This fluffy scarf made of a premium alpaca/wool blend with see you warmly and stylishly through the winter. Mega lush combined with the matching headband.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = scarvesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/121EA1Q306_530_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/121EA1Q306_530_37?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(scarves);
            await dbContext.SaveChangesAsync();
        }
    }
}
