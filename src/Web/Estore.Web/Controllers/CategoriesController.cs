namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string categoryId)
        {
            try
            {
                var subCategoriesViewModel = new MainCategoryViewModel
                {
                    //Categories = await this.categoriesService.GetSubCategories<SubMainCategoryViewModel>(categoryId),
                };

                return this.View(subCategoriesViewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }
    }
}
