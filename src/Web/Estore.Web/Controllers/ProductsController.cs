namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Categories;
    using Estore.Web.ViewModels.Products;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private const int ItemsPerPage = 3;
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductsController(
            IProductsService productsService,
            ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Clothes(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubMainModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Accessories(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubMainModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Shoes(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Boys(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubMainModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Girls(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubMainModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Bathroom(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Living(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Jeans(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Shirts(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Jackets(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Belts(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sunglasses(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Dresses(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Scarves(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Bags(string id, int page = 1)
        {
            try
            {
                var model = await this.GetSubModel(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var model = await this.productsService.GetDetailsAsync(id);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(ProductsSearchInputModel inputModel)
        {
            try
            {
                var model = new ProductsBySearchViewModel
                {
                    Keyword = inputModel.Keyword,
                    Products = await this.productsService.GetBySearchTermAsync<ProductViewModel>(inputModel.Keyword),
                };

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        private async Task<ProductstByCategoryViewModel> GetSubMainModel(string id, int page)
        {
            var subMainCategoryProductsModel = new ProductstByCategoryViewModel
            {
                CategoryId = id,
                CategoryName = await this.categoriesService.GetNameAsync(id),
                CategoriesProductsCount = await this.productsService.GetSubMainCategoryProductsCountAsync(id),
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                CategoryProducts = await this.productsService.GetSubMainCategoryProductsAsync<ProductViewModel>(id, page, ItemsPerPage),
            };

            return subMainCategoryProductsModel;
        }

        private async Task<ProductstByCategoryViewModel> GetSubModel(string id, int page)
        {
            var subCategoryProductsModel = new ProductstByCategoryViewModel
            {
                CategoryId = id,
                CategoryName = await this.categoriesService.GetNameAsync(id),
                CategoriesProductsCount = await this.productsService.GetSubCategoryProductsCountAsync(id),
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                CategoryProducts = await this.productsService.GetSubCategoryProductsAsync<ProductViewModel>(id, page, ItemsPerPage),
            };

            return subCategoryProductsModel;
        }
    }
}
