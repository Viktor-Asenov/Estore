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
		private readonly IProductsService productsService;

		public ReviewsController(
			IReviewsService reviewsService,
			IProductsService productsService)
		{
			this.reviewsService = reviewsService;
			this.productsService = productsService;
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
		public async Task<IActionResult> Edit(string id)
		{
			var inputModel = await this.reviewsService.GetByIdAsync<EditReviewInputModel>(id);
			inputModel.Products = await this.productsService.GetAllAsKeyValuePairsAsync();

			return this.View(inputModel);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, EditReviewInputModel input)
		{
			try
			{
				await this.reviewsService.EditAsync(id, input);

				return this.RedirectToAction(nameof(this.Index));
			}
			catch (Exception)
			{
				input.Products = await this.productsService.GetAllAsKeyValuePairsAsync();

				return this.View(input);
			}
			
		}
	}
}
