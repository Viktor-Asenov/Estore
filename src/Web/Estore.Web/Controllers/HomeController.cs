namespace Estore.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Estore.Data;
    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels;
    using Estore.Web.ViewModels.Categories;
    using Estore.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var mainCategories = await this.categoriesService
                .GetAllMain();
            foreach (var mainCategory in mainCategories)
            {
                var subMainCategories = await this.categoriesService.GetSubMain(mainCategory.Id);
                foreach (var subMainCategory in subMainCategories)
                {
                    var subCategories = await this.categoriesService.GetSub(subMainCategory.Id);
                    foreach (var subCategory in subCategories)
                    {
                        subMainCategory.SubCategories.Add(subCategory);
                    }
                }

                mainCategory.SubMainCategories = subMainCategories;
            }

            var mainMenuViewModel = new MainMenuViewModel
            {
                MainCategories = mainCategories,
            };

            return this.View(mainMenuViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
