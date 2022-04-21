namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext context;

        public CategoriesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetMainCategoriesAsync<T>()
        {
            var categories = await this.context.Categories
                .Where(c => c.ParentCategoryId == null)
                .OrderByDescending(mc => mc.Name.StartsWith("M"))
                .ThenByDescending(mc => mc.Name.StartsWith("W"))
                .ThenByDescending(mc => mc.Name.StartsWith("K"))
                .ThenByDescending(mc => mc.Name.StartsWith("H"))
                .To<T>()
                .ToListAsync();

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

        public IQueryable<T> GetSubSubMainCategories<T>(string parentCategoryId)
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

        public IQueryable<T> GetAllSubCategories<T>()
        {
            var allSubCategories = this.context.Categories
                .Where(c => c.ParentCategoryId != null)
                .To<T>();

            return allSubCategories;
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
    }
}
