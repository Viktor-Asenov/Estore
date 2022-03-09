namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;
    using Estore.Data.Models.Enumerations;

    internal class MenProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any())
            {
                return;
            }

            // ########## JACKETS CATEGORY ##########
            var jacketsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jackets" && c.ParentCategory.Name == "Men");

            var jackets = new List<Product>
            {
                new()
                {
                    Name = "Jackets outdoor woven",
                    Price = 100,
                    Description = "Outer fabric: 100% Polyester (recycled)",
                    Discount = 0,
                    ItemApplyDiscount = 2,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE2G305_001_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE2G305_001_14?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLACK, },
                },
                new()
                {
                    Name = "Padded jacket with wool",
                    Price = 100,
                    Description = "An all-rounder for cold weather, this melange coat is made with wool and partially recycled fibres and features a detachable stand-up collar.",
                    Discount = 40,
                    ItemApplyDiscount = 2,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/101EE2G308_010_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/101EE2G308_010_14?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLACK, Color.ANTHRACITE, Color.CAMEL, },
                },
                new()
                {
                    Name = "Recycled: Quilted jacket with 3M Thinsulate",
                    Price = 100,
                    Description = "This quilted jacket with innovative 3M Thinsulate technology is the perfect way to add extra warmth to your outfits.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EE2G302_001_20?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLACK, Color.DARKBLUE },
                },
                new()
                {
                    Name = "Outdoor jacket",
                    Price = 140,
                    Description = "Organic cotton: cotton organically cultivated in a controlled setting. High-fastening collar with set-in hood and a drawstring",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = jacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE2G303_291_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE2G303_291_14?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.XS, Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.LIGHTBEIGE },
                },
            };

            await dbContext.Products.AddRangeAsync(jackets);

            // ########## JEANS CATEGORY ##########
            var jeansCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jeans" && c.ParentCategory.Name == "Men");

            var jeans = new List<Product>
            {
                new()
                {
                    Name = "Basic jeans with organic cotton",
                    Price = 39,
                    Description = "Must-have basic: these jeans score major points with casual garment-washed effects and valuable organic cotton",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990CC2B302_922_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990CC2B302_922_11?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.GREY, Color.DARKBLUE },
                },
                new()
                {
                    Name = "Organic cotton jeans",
                    Price = 60,
                    Description = "A must-have fashion essential for every wardrobe: Indigo-dyed five-pocket jeans made with environmentally friendly, high-quality organic cotton.",
                    Discount = 15,
                    ItemApplyDiscount = 3,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990CC2B307_905_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990CC2B307_905_11?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLUEBLACK },
                },
                new()
                {
                    Name = "Stretch jeans containing organic cotton",
                    Price = 60,
                    Description = "A must-have fashion essential for every wardrobe: Indigo-dyed five-pocket jeans made with environmentally friendly, high-quality organic cotton.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EE2B307_902_13?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EE2B307_902_20?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLUE, },
                },
                new()
                {
                    Name = "Garment washed jeans, organic cotton",
                    Price = 60,
                    Description = "A must-have essential for every wardrobe: black 5-pocket jeans with gently processed, high-quality organic cotton.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = jeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EE2B308_911_20?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLACK },
                },
            };

            await dbContext.Products.AddRangeAsync(jeans);

            // ########## SHIRTS CATEGORY ##########
            var shirtsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Shirts" && c.ParentCategory.Name == "Men");

            var shirts = new List<Product>
            {
                new()
                {
                    Name = "Piqué long sleeve top, mercerised organic cotton",
                    Price = 56,
                    Description = "In a smart shirt style: this long sleeve top with a stand-up collar boasts premium piqué made of mercerised organic cotton.",
                    Discount = 20,
                    ItemApplyDiscount = 4,
                    CategoryId = shirtsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EO2F302_001_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/991EO2F302_001_16?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLACK, Color.OFFWHITE, },
                },
                new()
                {
                    Name = "Cotton shirt with band collar",
                    Price = 40,
                    Description = "Can be paired with chinos or jeans: this shirt with a casual band collar will complement all of your looks.",
                    Discount = 35,
                    ItemApplyDiscount = 2,
                    CategoryId = shirtsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/992EE2F301_100_10?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.WHITE },
                },
                new()
                {
                    Name = "Top with a button-down collar",
                    Price = 48,
                    Description = "Woven fabric in pure cotton. Sporty button-down collar.Button-fastening cuffs. Straight cut",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = shirtsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE2F301_470_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/012EE2F301_470_14?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.TURQUOISE },
                },
                new()
                {
                    Name = "Check shirt in cotton",
                    Price = 48,
                    Description = "Woven fabric in pure cotton. Classic turn-down collar. Patch breast pocket. Woven checks. Button-fastening cuffs",
                    Discount = 25,
                    ItemApplyDiscount = 2,
                    CategoryId = shirtsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE2F305_430_10?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE2F305_430_14?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EE2F305_430_16?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.S, Size.M, Size.L, Size.XL, },
                    Colors = new List<Color> { Color.BLUE, Color.DUSTYNUDE, },
                },
            };

            await dbContext.Products.AddRangeAsync(shirts);

            // ########## SHOES CATEGORY ##########
            var shoesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Shoes" && c.ParentCategory.Name == "Men");

            var shoes = new List<Product>
            {
                new()
                {
                    Name = "Lace-up boots in faux suede",
                    Price = 79,
                    Description = "Absolutely perfect for stylish looks: lace - up boots made of premium faux suede with contrasting colour, details finished in smooth faux leather.",
                    Discount = 30,
                    ItemApplyDiscount = 2,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W307_235_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W307_235_31?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.CARAMEL, },
                },
                new()
                {
                    Name = "Chelsea boots in imitation suede",
                    Price = 79,
                    Description = "These stylish Chelsea boots in imitation suede are the perfect everyday accessory.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W308_285_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W308_285_31?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.SAND, },
                },
                new()
                {
                    Name = "Lace-up boots in faux suede",
                    Price = 80,
                    Description = "Absolutely perfect for stylish looks: lace - up boots made of premium faux suede with contrasting colour, details finished in smooth faux leather.",
                    Discount = 30,
                    ItemApplyDiscount = 2,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W307_285_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/091EK2W307_285_31?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.SAND, },
                },
                new()
                {
                    Name = "Various Shoes textile",
                    Price = 36,
                    Description = "Outer fabric: 95 % Cotton, 5 % Polyurethane",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = shoesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032EK2W303_400_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/032EK2W303_400_31?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.NAVY },
                },
            };

            await dbContext.Products.AddRangeAsync(shoes);

            // ########## BELTS CATEGORY ##########
            var beltsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Belts" && c.ParentCategory.Name == "Men");

            var belts = new List<Product>
            {
                new()
                {
                    Name = "Nubuck leather belt",
                    Price = 30,
                    Description = "The solid metal buckle with a vintage finish completes the rugged look of this belt.",
                    Discount = 10,
                    ItemApplyDiscount = 4,
                    CategoryId = beltsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA2S302_230_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/990EA2S302_230_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.CAMEL, },
                },
                new()
                {
                    Name = "Leather belt with a satined metal buckle",
                    Price = 20,
                    Description = "Your universal fashion basic, whether with chinos or as a smart suit look: leather belt with a satined buckle.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = beltsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/998EA2S800_001_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/998EA2S800_001_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.BLACK },
                },
                new()
                {
                    Name = "Leather belt",
                    Price = 36,
                    Description = "Five classic buckle holes. Pointed tip",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = beltsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EA2S302_220_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/022EA2S302_220_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.BROWN, },
                },
                new()
                {
                    Name = "Basic smooth leather belt",
                    Price = 20,
                    Description = "Your fashion essential: its understated, timeless design and fine, smooth leather make this belt absolutely awesome.",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = beltsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/999EA2S805_001_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/999EA2S805_001_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> {  },
                    Colors = new List<Color> { Color.BLACK, },
                },
            };

            await dbContext.Products.AddRangeAsync(belts);

            // ########## SUNGLASSES CATEGORY ##########
            var sunglassesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Sunglasses" && c.ParentCategory.Name == "Men");

            var sunglasses = new List<Product>
            {
                new()
                {
                    Name = "Lightweight acetate sunglasses",
                    Price = 30,
                    Description = "Feel good and look good in these light sunglasses. Their minimalist design makes them suitable for every occasion.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39129S_538_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39129S_538_36?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39129S_538_37?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.UNIVERSAL },
                    Colors = new List<Color> { Color.BLACK, },
                },
                new()
                {
                    Name = "Sunglasses",
                    Price = 40,
                    Description = "The design suits round, heart-shaped and oval faces. Slightly mirrored lenses. UV filter category 3: provides UV protection against very bright sunlight",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39199S_538_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/39199S_538_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.UNIVERSAL },
                    Colors = new List<Color> { Color.BLACK, },
                },
                new()
                {
                    Name = "Sunglasses with mirrored lenses",
                    Price = 40,
                    Description = "The design suits round, heart-shaped and oval faces. Mirrored lenses. UV filter category 3: provides UV protection against very bright sunlight",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/19670S_577_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/19670S_577_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.UNIVERSAL },
                    Colors = new List<Color> { Color.PURPLE, },
                },
                new()
                {
                    Name = "Sports sunglasses with mirrored lenses",
                    Price = 50,
                    Description = "UV filter category 3: provides UV protection against very bright sunlight. Mirrored lenses. The design suits round, heart-shaped and oval faces",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = sunglassesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/19672S_531_30?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/19672S_531_36?$SFCC_L$",
                        },
                    },
                    Sizes = new List<Size> { Size.UNIVERSAL },
                    Colors = new List<Color> { Color.RED, },
                },
            };

            await dbContext.Products.AddRangeAsync(sunglasses);
            await dbContext.SaveChangesAsync();
        }
    }
}
