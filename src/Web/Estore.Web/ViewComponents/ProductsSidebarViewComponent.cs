namespace Estore.Web.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents.ProductsSidebar;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ProductsSidebarViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;
        private readonly ITagsService tagsService;

        public ProductsSidebarViewComponent(ICategoriesService categoriesService, ITagsService tagsService)
        {
            this.categoriesService = categoriesService;
            this.tagsService = tagsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productsSidebarModel = new ProductsSidebarViewModel
            {
                Categories = await this.categoriesService.GetAllSubCategories<SidebarCategoryViewModel>().ToListAsync(),
                Tags = await this.tagsService.GetAllTagsAsync<TagViewModel>(),
            };

            return this.View(productsSidebarModel);
        }
    }
}
