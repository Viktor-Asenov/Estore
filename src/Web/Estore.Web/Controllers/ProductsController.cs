namespace Estore.Web.Controllers
{
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Products;
    using Estore.Web.ViewModels.Tags;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private const int ItemsPerPage = 3;
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
                CategoryId = id,
                CategoryName = await this.categoriesService.GetName(id),
                CategoryImage = await this.categoriesService.GetImage(id),
                CategoriesProductsCount = await this.productsService.GetCount(id),
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                CategoryProducts = await this.productsService.GetAllByCategory<ProductInCategoryViewModel>(id, page, ItemsPerPage),
                Tags = await this.tagsService.GetAllTags<TagViewModel>(),
            };

            return this.View(productsByCategoryModel);
        }
    }
}
