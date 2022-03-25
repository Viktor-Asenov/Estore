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
            var result = await IfCategoryExistsAsync(categoryId);

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
            var result = await this.IfCategoryExistsAsync(categoryId);

            var subCategoryProducts = this.context.Products
                    .Where(p => p.Category.Id == result.Id)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync();

            return await subCategoryProducts;
        }

        public async Task<int> GetSubMainCategoryProductsCountAsync(string categoryId)
        {
            var result = await this.IfCategoryExistsAsync(categoryId);

            var subMainCategoryProducts = await this.context.Products
                .Where(p => p.Category.ParentCategoryId == result.Id)
                .ToListAsync();

            return subMainCategoryProducts.Count();
        }

        public async Task<int> GetSubCategoryProductsCountAsync(string categoryId)
        {
            var result = await this.IfCategoryExistsAsync(categoryId);

            var subMainCategoryProducts = await this.context.Products
                .Where(p => p.Category.Id == result.Id)
                .ToListAsync();

            return subMainCategoryProducts.Count();
        }

        private async Task<Category> IfCategoryExistsAsync(string categoryId)
        {
            var category = await this.context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null)
            {
                throw new NullReferenceException();
            }

            return category;
        }
    }
}
