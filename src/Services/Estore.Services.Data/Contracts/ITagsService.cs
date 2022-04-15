namespace Estore.Services.Data.Contracts
{
    using Estore.Web.ViewModels.Tags;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITagsService
    {
        Task<IEnumerable<T>> GetAllTagsAsync<T>();

        Task<IEnumerable<TagProductViewModel>> GetProductsByTagAsync(string tagId, int page, int itemsPerPage);

        Task<string> GetNameAsync(string tagId);

        Task<int> GetTagProductsCountAsync(string tagId);
    }
}
