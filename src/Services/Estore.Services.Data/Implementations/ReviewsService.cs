namespace Estore.Services.Data.Implementations
{
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Data.Models;
    using Estore.Services.Data.Contracts;
	using Estore.Services.Mapping;
	using Estore.Web.ViewModels.Reviews;
    using Microsoft.EntityFrameworkCore;

    public class ReviewsService : IReviewsService
    {
        private readonly ApplicationDbContext context;

        public ReviewsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> CreateReview(ReviewInputModel model)
        {
            var product = await this.context.Products
                .FirstOrDefaultAsync(p => p.Id == model.ProductId);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            var review = new Review
            {
                ProductId = product.Id,
                Author = model.Author,
                Content = model.Content,
                CreatedOn = DateTime.UtcNow,
            };

            await this.context.Reviews.AddAsync(review);
            await this.context.SaveChangesAsync();

            return "Thank you for your valuable opinion.";
        }

        public async Task<IEnumerable<T>> GetAll<T>()
		{
            var reviews = await this.context.Reviews
                .To<T>()
                .ToListAsync();

            return reviews;
		}

        public async Task<T> GetByIdAsync<T>(string id)
		{
            var review = await this.context.Reviews
                .Where(r => r.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return review;
		}

        public async Task EditAsync(string id, EditReviewInputModel input)
		{

		}
    }
}
