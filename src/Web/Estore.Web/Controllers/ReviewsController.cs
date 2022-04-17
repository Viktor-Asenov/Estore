namespace Estore.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Estore.Services.Data.Contracts;
    using Estore.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ReviewsController : BaseController
    {
        private readonly IReviewsService reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            try
            {
                var inputModel = new ReviewInputModel { ProductId = id };

                return this.View(inputModel);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewInputModel model)
        {
            try
            {
                await this.reviewsService.CreateReview(model);

                return this.Redirect("/Products/Details/" + model.ProductId);
            }
            catch (Exception)
            {
                return this.Redirect("/Home/Error");
            }
        }
    }
}
