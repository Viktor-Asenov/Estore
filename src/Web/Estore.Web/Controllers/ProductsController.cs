namespace Estore.Web.Controllers
{
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Products;
    using Estore.Web.ViewModels.Tags;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;
        private readonly ITagsService tagsService;

        public ProductsController(IProductsService productsService, ITagsService tagsService)
        {
            this.productsService = productsService;
            this.tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> AllByCategory(int page, string categoryId)
        {
            var productsByCategory = new ProductstByCategoryViewModel
            {
                CategoryProducts = await this.productsService.GetAllByCategory<ProductInCategoryViewModel>(page, 10, categoryId),
                Tags = await this.tagsService.GetAllTags<TagViewModel>(),
                PageNumber = page,
            };

            return this.View(productsByCategory);
        }
    }
}
