namespace Estore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Men(string id)
        {
            try
            {
                var subCategoriesMenModel = new SubCategoriesListViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetNameAsync(id),
                    SubCategories = await this.categoriesService
                    .GetSubSubMainCategories<CategoryViewModel>(id)
                    .OrderByDescending(sc => sc.Name.StartsWith("Ja"))
                    .ThenByDescending(sc => sc.Name.StartsWith("J"))
                    .ThenByDescending(sc => sc.Name.StartsWith("Sh"))
                    .ToListAsync(),
                };

                return this.View(subCategoriesMenModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Women(string id)
        {
            try
            {
                var subCategoriesWomenModel = new SubCategoriesListViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetNameAsync(id),
                    SubCategories = await this.categoriesService
                    .GetSubSubMainCategories<CategoryViewModel>(id)
                    .OrderByDescending(sc => sc.Name.StartsWith("Ja"))
                    .ThenByDescending(sc => sc.Name.StartsWith("J"))
                    .ThenByDescending(sc => sc.Name.StartsWith("D"))
                    .ToListAsync(),
                };

                return this.View(subCategoriesWomenModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Kids(string id)
        {
            try
            {
                var subMainCategoriesKidsModel = new SubCategoriesListViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetNameAsync(id),
                    SubCategories = await this.categoriesService
                    .GetSubMainCategories<CategoryViewModel>(id)
                    .OrderByDescending(c => c.Name.StartsWith("B"))
                    .ToListAsync(),
                };

                return this.View(subMainCategoriesKidsModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Boys(string id)
        {
            try
            {
                var subMainCategoriesBoysModel = new SubCategoriesListViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetNameAsync(id),
                    SubCategories = await this.categoriesService
                    .GetSubMainCategories<CategoryViewModel>(id)
                    .OrderByDescending(sc => sc.Name.StartsWith("Ja"))
                    .ToListAsync(),
                };

                return this.View(subMainCategoriesBoysModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Girls(string id)
        {
            try
            {
                var subMainCategoriesGirlsModel = new SubCategoriesListViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetNameAsync(id),
                    SubCategories = await this.categoriesService
                    .GetSubMainCategories<CategoryViewModel>(id)
                    .OrderByDescending(sc => sc.Name.StartsWith("Ja"))
                    .ThenByDescending(sc => sc.Name.StartsWith("J"))
                    .ToListAsync(),
                };

                return this.View(subMainCategoriesGirlsModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Home(string id)
        {
            try
            {
                var subMainCategoriesHomeModel = new SubCategoriesListViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetNameAsync(id),
                    SubCategories = await this.categoriesService
                    .GetSubMainCategories<CategoryViewModel>(id)
                    .OrderByDescending(c => c.Name.StartsWith("B"))
                    .ToListAsync(),
                };

                return this.View(subMainCategoriesHomeModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }
    }
}
