namespace Estore.Web.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents;
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
                .GetMainCategories<MainCategoryMenuViewModel>()
                .OrderByDescending(mc => mc.Name.StartsWith("M"))
                .ThenByDescending(mc => mc.Name.StartsWith("W"))
                .ThenByDescending(mc => mc.Name.StartsWith("K"))
                .ThenByDescending(mc => mc.Name.StartsWith("H"))
                .ToListAsync();

            foreach (var mainCategory in mainCategories)
            {
                var subMainCategories = await this.categoriesService
                    .GetSubMainCategories<SubMainCategoryMenuViewModel>(mainCategory.Id)
                    .OrderByDescending(smc => smc.Name.StartsWith("C"))
                    .ThenByDescending(smc => smc.Name.StartsWith("A"))
                    .ThenByDescending(smc => smc.Name.StartsWith("S"))
                    .ToListAsync();

                foreach (var subMainCategory in subMainCategories)
                {
                    var subCategories = await this.categoriesService
                        .GetSubCategories<SubCategoryMenuViewModel>(subMainCategory.Id)
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
