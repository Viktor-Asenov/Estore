namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Tags;
    using Microsoft.AspNetCore.Mvc;

    public class TagsController : BaseController
    {
        private const int ItemsPerPage = 3;
        private readonly ITagsService tagsService;

        public TagsController(ITagsService tagsService)
        {
            this.tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> Organic(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Leather(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Fashion(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Vegan(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Recycled(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Slim(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sustainable(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        private async Task<TagProductsViewModel> GetModelAsync(string id, int page)
        {
            var model = new TagProductsViewModel
            {
                TagId = id,
                TagName = await this.tagsService.GetNameAsync(id),
                TagProductsCount = await this.tagsService.GetTagProductsCountAsync(id),
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                TagProducts = await this.tagsService.GetProductsByTagAsync(id, page, ItemsPerPage),
            };

            return model;
        }
    }
}
