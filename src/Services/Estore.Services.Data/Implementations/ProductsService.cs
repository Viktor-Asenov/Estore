namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Data.Models;
    using Estore.Data.Models.Enumerations;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Products;
    using Estore.Web.ViewModels.Products.Enums;
    using Microsoft.EntityFrameworkCore;

    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext context;

        public ProductsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetSubMainCategoryProductsAsync<T>(string categoryId, int page, int itemsPerPage)
        {
            var result = await this.IfCategoryExistAsync(categoryId);

            var subMainCategoryProducts = this.context.Products
                    .Where(p => p.Category.ParentCategoryId == result.Id)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync();

            return await subMainCategoryProducts;
        }

        public async Task<IEnumerable<T>> GetSubCategoryProductsAsync<T>(string categoryId, int page, int itemsPerPage)
        {
            var result = await this.IfCategoryExistAsync(categoryId);

            var subCategoryProducts = await this.context.Products
                    .Where(p => p.Category.Id == result.Id)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync();

            return subCategoryProducts;
        }

        public async Task<int> GetSubMainCategoryProductsCountAsync(string categoryId)
        {
            var result = await this.IfCategoryExistAsync(categoryId);

            var subMainCategoryProducts = await this.context.Products
                .Where(p => p.Category.ParentCategoryId == result.Id)
                .ToListAsync();

            return subMainCategoryProducts.Count();
        }

        public async Task<int> GetSubCategoryProductsCountAsync(string categoryId)
        {
            var result = await this.IfCategoryExistAsync(categoryId);

            var subMainCategoryProducts = await this.context.Products
                .Where(p => p.Category.Id == result.Id)
                .ToListAsync();

            return subMainCategoryProducts.Count();
        }

        public async Task<ProductDetailsViewModel> GetDetailsAsync(string productId)
        {
            var result = await this.IfProductExistAsync(productId);

            var product = await this.context.Products
                .Where(p => p.Id == result.Id)
                .To<ProductDetailsViewModel>()
                .FirstOrDefaultAsync();

            product.RelatedProducts = await this.GetRelated(productId);
            product.Colors = await this.GetColorsAsync(productId);
            product.Measures = await this.GetMeasuresAsync(productId);

            return product;
        }

        private async Task<IEnumerable<RelatedProductViewModel>> GetRelated(string productId)
        {
            var product = await this.IfProductExistAsync(productId);

            var relatedProducts = await this.context.Products
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .To<RelatedProductViewModel>()
                .ToListAsync();

            return relatedProducts;
        }

        private async Task<IEnumerable<ColorType>> GetColorsAsync(string productId)
        {
            var result = await this.IfProductExistAsync(productId);

            var productColors = result.Colors
                .Select(c => new ColorType { })
                .ToList();

            return productColors;
        }

        private async Task<IEnumerable<Measure>> GetMeasuresAsync(string productId)
        {
            var result = await this.IfProductExistAsync(productId);

            var productMeasures = result.Sizes
                .Select(s => new Measure { })
                .ToList();

            return productMeasures;
        }

        private async Task<Category> IfCategoryExistAsync(string categoryId)
        {
            var category = await this.context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null)
            {
                throw new NullReferenceException();
            }

            return category;
        }

        private async Task<Product> IfProductExistAsync(string productId)
        {
            var product = await this.context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product;
        }
    }
}
