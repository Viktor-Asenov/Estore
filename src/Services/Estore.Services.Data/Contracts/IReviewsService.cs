namespace Estore.Services.Data.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Estore.Web.ViewModels.Administration.Reviews;
	using Estore.Web.ViewModels.Reviews;

    public interface IReviewsService
    {
        Task<string> CreateReview(ReviewInputModel model);

        Task<IEnumerable<T>> GetAll<T>();

        Task<T> GetByIdAsync<T>(string id);

        Task EditAsync(string id, EditReviewInputModel input);

        Task DeleteAsync(string id);
    }
}
