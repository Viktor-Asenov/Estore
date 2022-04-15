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

        public async Task<IActionResult> Organic(string id, int page = 1)
        {
            try
            {
                var model = await this.GetModelAsync(id, page);

                return this.View(model);
            }
            catch (Exception ex)
            {
                return this.NotFound(ex.Message);
            }
        }

        private async Task<TagProductsViewModel> GetModelAsync(string id, int page)
        {
            var model = new TagProductsViewModel
            {
                TagId = id,
                TagName = await this.tagsService.GetNameAsync(id),
                TagProductsCount = await this.tagsService.GetTagProductsCountAsync(id),
                TagProducts = await this.tagsService.GetProductsByTagAsync(id, page, ItemsPerPage),
            };

            return model;
        }
    }
}
