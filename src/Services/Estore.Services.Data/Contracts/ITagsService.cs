namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Estore.Web.ViewModels.Tags;

    public interface ITagsService
    {
        Task<IEnumerable<T>> GetAllTagsAsync<T>();

        Task<IEnumerable<TagProductViewModel>> GetProductsByTagAsync(string tagId, int page, int itemsPerPage);

        Task<string> GetNameAsync(string tagId);

        Task<int> GetTagProductsCountAsync(string tagId);
    }
}
