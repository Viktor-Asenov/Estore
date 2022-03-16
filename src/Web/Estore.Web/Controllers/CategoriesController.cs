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
                var allSubCategoriesModel = new AllSubCategoriesViewModel
                {
                    SubCategories = await this.categoriesService
                    .GetSubCategories<CategoryViewModel>(id)
                    .ToListAsync(),
                };

                return this.View(allSubCategoriesModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }
    }
}
