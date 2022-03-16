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

        public IQueryable<T> GetMainCategories<T>()
        {
            var categories = this.context.Categories
                .Where(c => c.ParentCategoryId == null)
                .To<T>();

            return categories;
        }

        public IQueryable<T> GetSubMainCategories<T>(string parentCategoryId)
        {
            if (parentCategoryId == null)
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
            if (parentCategoryId == null)
            {
                throw new ArgumentNullException();
            }

            var subCategories = this.context.Categories
                .Where(c => c.ParentCategory.ParentCategoryId == parentCategoryId)
                .To<T>();

            return subCategories;
        }
    }
}
