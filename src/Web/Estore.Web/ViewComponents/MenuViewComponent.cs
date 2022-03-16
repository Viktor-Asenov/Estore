namespace Estore.Web.ViewComponents
{
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents;
    using Microsoft.AspNetCore.Mvc;

    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public MenuViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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

            var mainMenuModel = new MainMenuViewModel
            {
                MainCategories = mainCategories,
            };

            return this.View(mainMenuModel);
        }
    }
}
