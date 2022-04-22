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
    using Estore.Web.ViewModels.Products;
	using Estore.Web.ViewModels.Reviews;
	using Microsoft.EntityFrameworkCore;

    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext context;

        public ProductsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetLatestAsync<T>()
        {
            var latestProducts = await this.context.Products
                .OrderByDescending(p => p.CreatedOn)
                .Take(10)
                .To<T>()
                .ToListAsync();

            return latestProducts;
        }

        public async Task<IEnumerable<T>> GetMostDiscountedAsync<T>()
        {
            var mostDiscounted = await this.context.Products
                .OrderByDescending(p => p.Discount)
                .Take(10)
                .To<T>()
                .ToListAsync();

            return mostDiscounted;
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

            var productDetails = await this.context.Products
                .Where(p => p.Id == result.Id)
                .To<ProductDetailsViewModel>()
                .FirstOrDefaultAsync();

            productDetails.Reviews = await this.GetReviewsAsync(productId);
            productDetails.RelatedProducts = await this.GetRelatedAsync(productId);

            return productDetails;
        }

        public async Task<IEnumerable<T>> GetBySearchTermAsync<T>(string keyword)
		{
            var searchTerm = string.Empty;
            if (keyword.ToLower().EndsWith('s'))
			{
                searchTerm = keyword.Substring(0, keyword.Length - 1);
			}
            else
			{
                searchTerm = keyword;
            }

            var foundProducts = await this.context.Products
                .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()))
                .To<T>()
                .ToListAsync();

            return foundProducts;
		}

        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync()
		{
            var products = await this.context.Products
                .ToListAsync();
            var keyValuePairs = new List<KeyValuePair<string, string>>();


            foreach (var product in products)
			{
                keyValuePairs.Add(new KeyValuePair<string, string>(product.Id, product.Name));
            }

            return keyValuePairs;
		}

        private async Task<IEnumerable<ReviewViewModel>> GetReviewsAsync(string productId)
        {
            var product = await this.IfProductExistAsync(productId);

            var reviews = await this.context.Reviews
                .Where(r => r.ProductId == product.Id)
                .To<ReviewViewModel>()
                .ToListAsync();

            return reviews;
        }

        private async Task<IEnumerable<ProductViewModel>> GetRelatedAsync(string productId)
        {
            var product = await this.IfProductExistAsync(productId);

            var relatedProducts = await this.context.Products
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
                .To<ProductViewModel>()
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
