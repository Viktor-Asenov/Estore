namespace Estore.Web.Controllers
{
    using System;
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
                var subCategoriesMenModel = new AllSubCategoriesViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetParentName(id),
                    SubCategories = await this.categoriesService
                    .GetSubCategories<CategoryViewModel>(id)
                    .ToListAsync(),
                };

                return this.View(subCategoriesMenModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Women(string id)
        {
            try
            {
                var subCategoriesWomenModel = new AllSubCategoriesViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetParentName(id),
                    SubCategories = await this.categoriesService
                    .GetSubCategories<CategoryViewModel>(id)
                    .ToListAsync(),
                };

                return this.View(subCategoriesWomenModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Kids(string id)
        {
            try
            {
                var subMainCategoriesKidsModel = new AllSubCategoriesViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetParentName(id),
                    SubCategories = await this.categoriesService
                    .GetSubMainCategories<CategoryViewModel>(id)
                    .ToListAsync(),
                };

                return this.View(subMainCategoriesKidsModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Home(string id)
        {
            try
            {
                var subMainCategoriesHomeModel = new AllSubCategoriesViewModel
                {
                    ParentCategoryName = await this.categoriesService.GetParentName(id),
                    SubCategories = await this.categoriesService
                    .GetSubMainCategories<CategoryViewModel>(id)
                    .ToListAsync(),
                };

                return this.View(subMainCategoriesHomeModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }
    }
}
