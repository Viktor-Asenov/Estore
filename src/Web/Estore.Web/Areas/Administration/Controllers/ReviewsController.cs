namespace Estore.Web.Areas.Administration.Controllers
{
	using System;
	using System.Threading.Tasks;

	using Estore.Services.Data.Contracts;
	using Estore.Web.ViewModels.Administration.Reviews;
	using Microsoft.AspNetCore.Mvc;

	public class ReviewsController : AdministrationController
	{
		private readonly IReviewsService reviewsService;

		public ReviewsController(IReviewsService reviewsService)
		{
			this.reviewsService = reviewsService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = new IndexViewModel
			{
				Reviews = await this.reviewsService.GetAll<AdministrationReviewViewModel>(), 
			};

			return this.View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string reviewId)
		{
			var inputModel = await this.reviewsService.GetByIdAsync<EditReviewInputModel>(reviewId);

			return this.View(inputModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string reviewId, EditReviewInputModel input)
		{
			try
			{
				return this.RedirectToAction(nameof(this.Index));
			}
			catch (Exception)
			{
				return this.View();
			}
			
		}
	}
}
