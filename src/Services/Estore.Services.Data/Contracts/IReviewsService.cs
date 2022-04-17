namespace Estore.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Estore.Web.ViewModels.Reviews;

    public interface IReviewsService
    {
        Task<string> CreateReview(ReviewInputModel model);
    }
}
