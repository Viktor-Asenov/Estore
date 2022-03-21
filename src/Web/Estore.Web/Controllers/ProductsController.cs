﻿namespace Estore.Web.Controllers
{
    using System;
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

        public ProductsController(
            IProductsService productsService,
            ICategoriesService categoriesService,
            ITagsService tagsService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> Clothes(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubMainModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Accessories(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubMainModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Shoes(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Boys(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubMainModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Girls(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubMainModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Bathroom(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Living(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sale(string id, int page = 1)
        {
            try
            {
                var viewModel = await this.GetSubModel(id, page);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        private async Task<ProductstByCategoryViewModel> GetSubMainModel(string id, int page)
        {
            var subMainCategoryProductsModel = new ProductstByCategoryViewModel
            {
                CategoryId = id,
                CategoryName = await this.categoriesService.GetNameAsync(id),
                CategoryImage = await this.categoriesService.GetImageAsync(id),
                CategoriesProductsCount = await this.productsService.GetSubMainCategoryProductsCountAsync(id),
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                CategoryProducts = await this.productsService.GetSubMainCategoryProductsAsync<ProductInCategoryViewModel>(id, page, ItemsPerPage),
                Tags = await this.tagsService.GetAllTagsAsync<TagViewModel>(),
            };

            return subMainCategoryProductsModel;
        }

        private async Task<ProductstByCategoryViewModel> GetSubModel(string id, int page)
        {
            var subCategoryProductsModel = new ProductstByCategoryViewModel
            {
                CategoryId = id,
                CategoryName = await this.categoriesService.GetNameAsync(id),
                CategoryImage = await this.categoriesService.GetImageAsync(id),
                CategoriesProductsCount = await this.productsService.GetSubCategoryProductsCountAsync(id),
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                CategoryProducts = await this.productsService.GetSubCategoryProductsAsync<ProductInCategoryViewModel>(id, page, ItemsPerPage),
                Tags = await this.tagsService.GetAllTagsAsync<TagViewModel>(),
            };

            return subCategoryProductsModel;
        }
    }
}
