namespace Estore.Web.Controllers
{
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Products;
    using Estore.Web.ViewModels.Tags;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private const int ItemsPerPage = 10;
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly ITagsService tagsService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService,
            ITagsService tagsService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> Clothes(string id, int page = 1)
        {
            var productsByCategoryModel = new ProductstByCategoryViewModel
            {
                CategoryName = await this.categoriesService.GetName(id),
                CategoryProducts = await this.productsService.GetAllByCategory<ProductInCategoryViewModel>(id, page, ItemsPerPage),
                Tags = await this.tagsService.GetAllTags<TagViewModel>(),
                PageNumber = page,
            };

            return this.View(productsByCategoryModel);
        }
    }
}
