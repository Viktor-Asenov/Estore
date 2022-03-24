namespace Estore.Web.ViewComponents
{
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.ViewComponents.ProductsSidebar;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsSidebarViewComponent : ViewComponent
    {
        private readonly ITagsService tagsService;

        public ProductsSidebarViewComponent(ITagsService tagsService)
        {
            this.tagsService = tagsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productsSidebarModel = new ProductsSidebarViewModel
            {
                Tags = await this.tagsService.GetAllTagsAsync<TagViewModel>(),
            };

            return this.View(productsSidebarModel);
        }
    }
}
