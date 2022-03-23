﻿namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Categories;
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

        public async Task<T> GetBreadcrumbCategoryAsync<T>(string categoryId)
        {
            var category = await this.context.Categories
                .Where(c => c.Id == categoryId)
                .To<T>()
                .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new ArgumentNullException();
            }

            return category;
        }
    }
}
