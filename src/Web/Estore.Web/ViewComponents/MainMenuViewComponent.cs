namespace Estore.Web.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents.MainMenu;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class MainMenuViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public MainMenuViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mainCategories = await this.categoriesService
                .GetMainCategoriesAsync<MainCategoryMenuViewModel>();

            foreach (var mainCategory in mainCategories)
            {
                var subMainCategories = await this.categoriesService
                    .GetSubMainCategories<SubMainCategoryMenuViewModel>(mainCategory.Id)
                    .OrderByDescending(smc => smc.Name.StartsWith("C"))
                    .ThenByDescending(smc => smc.Name.StartsWith("A"))
                    .ThenByDescending(smc => smc.Name.StartsWith("S"))
                    .ThenByDescending(smc => smc.Name.StartsWith("B"))
                    .ToListAsync();

                foreach (var subMainCategory in subMainCategories)
                {
                    var subCategories = await this.categoriesService
                        .GetSubSubMainCategories<SubCategoryMenuViewModel>(subMainCategory.Id)
                        .ToListAsync();

                    foreach (var subCategory in subCategories)
                    {
                        subMainCategory.SubCategories.Add(subCategory);
                    }
                }

                mainCategory.SubMainCategories = subMainCategories;
            }

            var mainMenuModel = new MainMenuViewModel
            {
                MainCategories = mainCategories,
            };

            return this.View(mainMenuModel);
        }
    }
}
