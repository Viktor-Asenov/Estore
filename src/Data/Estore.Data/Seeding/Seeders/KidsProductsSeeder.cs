namespace Estore.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data.Models;

    public class KidsProductsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Products.Any(p => p.Category.ParentCategory.ParentCategory.Name == "Kids"))
            {
                return;
            }

            // ########## PRODUCT TAGS ##########
            var sustainableTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Sustainable");
            var recycledTag = dbContext.Tags
                .FirstOrDefault(t => t.Name == "Recycled");

            // ############################## BOYS ##############################

            // ########## BOYS JACKETS CATEGORY ##########
            var boysJacketsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jackets" && c.ParentCategory.Name == "Boys");

            var boysJackets = new List<Product>
            {
                new()
                {
                    Name = "Quilted jacket with a hood",
                    Price = 44,
                    Description = "The sporty quilting and reflective details make this quilted jacket an everyday favourite on mild winter days.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = boysJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922044201_001_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922044201_001_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Jacket outdoor woven",
                    Price = 87,
                    Description = "Outer fabric: 100% Polyester (recycled). Filling: 100 % Polyester. Inner Lining: 100 % Polyester. Cord: 100 % Polyester.",
                    Discount = 25,
                    ItemApplyDiscount = 3,
                    CategoryId = boysJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7121064201_600_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7121064201_600_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Jacket outdoor",
                    Price = 58,
                    Description = "Outer fabric: 100% Polyester (recycled). Trimming: 100 % Polyester. Hood Lining: 100 % Cotton.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = boysJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230144202_400_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230144202_400_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Vest outdoor woven",
                    Price = 50,
                    Description = "Outer fabric: 100% Polyamide (recycled). Trimming: 100 % Polyester.",
                    Discount = 30,
                    ItemApplyDiscount = 4,
                    CategoryId = boysJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230144901_710_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230144901_710_21?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(boysJackets);

            // ########## BOYS JEANS CATEGORY ##########
            var boysJeansCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jeans" && c.ParentCategory.Name == "Boys");

            var boysJeans = new List<Product>
            {
                new()
                {
                    Name = "Pants denim",
                    Price = 30,
                    Description = "74% Cotton, 23% Polyester, 3% Elastane.",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = boysJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902162903_902_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902162903_902_25?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Pants denim",
                    Price = 40,
                    Description = "74% Cotton, 23% Polyester, 3% Elastane.",
                    Discount = 15,
                    ItemApplyDiscount = 3,
                    CategoryId = boysJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230162901_922_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230162901_922_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Shorts denim",
                    Price = 35,
                    Description = "Outer fabric: 91% Cotton, 6% Polyester, 3% Elastane.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = boysJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230262503_922_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230262503_922_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Washed stretch jeans with an adjustable waistband",
                    Price = 26,
                    Description = "These slim fit stretch jeans with a garment-washed effect are an exceptionally casual essential.",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = boysJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902042902_901_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902042902_901_21?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = recycledTag.Id },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(boysJeans);

            // ############################## GIRLS ##############################

            // ########## GIRLS JACKETS CATEGORY ##########
            var girlsJacketsCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jackets" && c.ParentCategory.Name == "Girls");

            var girlsJackets = new List<Product>
            {
                new()
                {
                    Name = "Padded quilted jacket with a hood",
                    Price = 50,
                    Description = "The sporty quilting and reflective details make this quilted jacket an everyday favourite on mild winter days.",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = girlsJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922054201_001_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922054201_001_21?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Quilted jacket with a hood",
                    Price = 45,
                    Description = "The sporty quilting and reflective details make this quilted jacket an everyday favourite on mild winter days.",
                    Discount = 10,
                    ItemApplyDiscount = 3,
                    CategoryId = girlsJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922034201_670_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9922034201_670_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Jacket outdoor woven",
                    Price = 50,
                    Description = "Outer fabric: 55% Polyester, 33% Cotton, 12% Polyamide. Trimming: 100 % Polyester. Lining: 100 % Cotton.",
                    Discount = 20,
                    ItemApplyDiscount = 2,
                    CategoryId = girlsJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230254202_361_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230254202_361_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Jacket",
                    Price = 56,
                    Description = "Outer fabric: 55% Polyester, 33% Cotton, 12% Polyamide. Trimming: 100 % Polyester. Lining: 100 % Cotton.",
                    Discount = 15,
                    ItemApplyDiscount = 3,
                    CategoryId = girlsJacketsCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230134202_661_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230134202_661_21?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = recycledTag.Id },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(girlsJackets);

            // ########## GIRLS JEANS CATEGORY ##########
            var girlsJeansCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Jeans" && c.ParentCategory.Name == "Girls");

            var girlsJeans = new List<Product>
            {
                new()
                {
                    Name = "Pants woven",
                    Price = 35,
                    Description = "Outer fabric: 96% Cotton, 4% Elastane",
                    Discount = 25,
                    ItemApplyDiscount = 3,
                    CategoryId = girlsJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230252201_610_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230252201_610_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Stretch jeans available in different widths with an adjustable waistband",
                    Price = 29,
                    Description = "Available in three different widths: these narrowly cut, stretch jeans with a garment-washed finish are a mega cool basic.",
                    Discount = 10,
                    ItemApplyDiscount = 4,
                    CategoryId = girlsJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902052903_902_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/9902052903_902_21?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = recycledTag.Id },
                    },
                },
                new()
                {
                    Name = "Shorts denim",
                    Price = 35,
                    Description = "Outer fabric: 96% Cotton, 4% Elastane",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = girlsJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230252502_901_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230252502_901_21?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Pants denim",
                    Price = 40,
                    Description = "Outer fabric: 96% Cotton, 4% Elastane",
                    Discount = 20,
                    ItemApplyDiscount = 3,
                    CategoryId = girlsJeansCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230152901_901_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230152901_901_21?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(girlsJeans);

            // ########## GIRLS DRESSES CATEGORY ##########
            var girlsDressesCategory = dbContext.Categories
                .FirstOrDefault(c => c.Name == "Dresses" && c.ParentCategory.Name == "Girls");

            var girlsDresses = new List<Product>
            {
                new()
                {
                    Name = "Dress knitted",
                    Price = 36,
                    Description = "Outer fabric: 96% Cotton, 4% Elastane",
                    Discount = 25,
                    ItemApplyDiscount = 3,
                    CategoryId = girlsDressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230253103_902_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230253103_902_21?$SFCC_L$",
                        },
                    },
                    ProductTags = new List<ProductTag>
                    {
                        new() { TagId = sustainableTag.Id },
                    },
                },
                new()
                {
                    Name = "Dress woven",
                    Price = 50,
                    Description = "Outer fabric: 100% Viscose",
                    Discount = null,
                    ItemApplyDiscount = 0,
                    CategoryId = girlsDressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230253004_403_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230253004_403_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Dress",
                    Price = 44,
                    Description = "Outer fabric: 100% Cotton. Trimming: 67 % Viscose, 33 % Polyester.",
                    Discount = 10,
                    ItemApplyDiscount = 2,
                    CategoryId = girlsDressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230233003_403_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7230233003_403_21?$SFCC_L$",
                        },
                    },
                },
                new()
                {
                    Name = "Denim dress",
                    Price = 40,
                    Description = "Soft cotton denim with added stretch for comfort. Side slit pockets.",
                    Discount = 20,
                    ItemApplyDiscount = 4,
                    CategoryId = girlsDressesCategory.Id,
                    Images = new List<Image>
                    {
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7121153001_911_27?$SFCC_L$",
                        },
                        new()
                        {
                            RemoteUrl = "https://esprit.scene7.com/is/image/esprit/7121153001_911_21?$SFCC_L$",
                        },
                    },
                },
            };

            await dbContext.Products.AddRangeAsync(girlsDresses);
            await dbContext.SaveChangesAsync();
        }
    }
}
