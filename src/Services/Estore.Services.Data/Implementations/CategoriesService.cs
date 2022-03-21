namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Estore.Data;
    using Estore.Data.Common.Repositories;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(ApplicationDbContext context, IRepository<Category> categoriesRepository)
        {
            this.context = context;
            this.categoriesRepository = categoriesRepository;
        }

        public IQueryable<T> GetMainCategories<T>()
        {
            var categories = this.context.Categories
                .Where(c => c.ParentCategoryId == null)
                .To<T>();

            return categories;
        }

        public IQueryable<T> GetSubMainCategories<T>(string parentCategoryId)
        {
            var parentCategory = this.context.Categories
                .FirstOrDefault(c => c.Id == parentCategoryId);
            if (parentCategory == null)
            {
                throw new ArgumentNullException();
            }

            var subMainCategories = this.context.Categories
                .Where(c => c.ParentCategoryId == parentCategoryId)
                .To<T>();

            return subMainCategories;
        }

        public IQueryable<T> GetSubCategories<T>(string parentCategoryId)
        {
            var parentCategory = this.context.Categories
                .FirstOrDefault(c => c.Id == parentCategoryId);
            if (parentCategory == null)
            {
                throw new ArgumentNullException();
            }

            var subCategories = this.context.Categories
                .Where(c => c.ParentCategory.ParentCategoryId == parentCategory.Id)
                .To<T>();

            return subCategories;
        }

        public async Task<string> GetNameAsync(string categoryId)
        {
            var category = await this.context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                throw new ArgumentNullException();
            }

            return category.Name;
        }

        public async Task<string> GetImageAsync(string categoryId)
        {
            var categoryImage = await this.context.Images
                .FirstOrDefaultAsync(i => i.CategoryId == categoryId);

            if (categoryImage == null)
            {
                throw new ArgumentNullException();
            }

            return categoryImage.ToString();
        }
    }
}
