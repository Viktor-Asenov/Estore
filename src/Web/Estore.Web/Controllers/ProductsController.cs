namespace Estore.Web.Controllers
{
    using System.Threading.Tasks;

    using Estore.Services.Data.Interfaces;
    using Estore.Web.ViewModels.Products;
    using Estore.Web.ViewModels.Tags;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> AllByCategory(int page, string categoryId)
        {
            var productsByCategory = new ProductstByCategoryViewModel
            {
                CategoryProducts = await this.productsService.GetAllByCategory<ProductInCategoryViewModel>(page, 10, categoryId),
                Tags = await this.productsService.GetAllTags<TagViewModel>(),
                PageNumber = page,
            };

            return this.View(productsByCategory);
        }
    }
}
