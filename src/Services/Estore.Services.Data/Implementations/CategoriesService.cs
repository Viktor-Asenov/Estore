namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
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

        public async Task<IEnumerable<MainCategoryViewModel>> GetAllMain()
        {
            var categories = this.context.Categories
                .Where(c => c.ParentCategoryId == null)
                .To<MainCategoryViewModel>()
                .OrderByDescending(mc => mc.Name.StartsWith("M"))
                .ThenByDescending(mc => mc.Name.StartsWith("W"))
                .ThenByDescending(mc => mc.Name.StartsWith("K"))
                .ThenByDescending(mc => mc.Name.StartsWith("H"))
                .ToListAsync();

            return await categories;
        }

        public async Task<IEnumerable<SubMainCategoryViewModel>> GetSubMain(string parentCategoryId)
        {
            var subMainCategories = await this.context.Categories
                .Where(c => c.ParentCategoryId == parentCategoryId)
                .To<SubMainCategoryViewModel>()
                .OrderByDescending(smc => smc.Name.StartsWith("C"))
                .ThenByDescending(smc => smc.Name.StartsWith("A"))
                .ThenByDescending(smc => smc.Name.StartsWith("S"))
                .ToListAsync();

            return subMainCategories;
        }

        public async Task<IEnumerable<SubCategoryViewModel>> GetSub(string parentCategoryId)
        {
            var subCategories = await this.context.Categories
                .Where(c => c.ParentCategory.ParentCategoryId == parentCategoryId)
                .To<SubCategoryViewModel>()
                .OrderBy(sc => sc.Name.StartsWith("J"))
                .ToListAsync();

            return subCategories;
        }
    }
}
