namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
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

        public async Task<T> GetDetailsAsync<T>(string productId)
        {
            var result = await this.IfProductExistAsync(productId);

            var product = await this.context.Products
                .Where(p => p.Id == result.Id)
                .To<T>()
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<T>> GetRelated<T>(string productId)
        {
            var product = await this.IfProductExistAsync(productId);

            var relatedProducts = await this.context.Products
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .To<T>()
                .ToListAsync();

            return relatedProducts;
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
