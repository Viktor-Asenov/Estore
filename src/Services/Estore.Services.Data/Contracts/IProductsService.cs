namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<IEnumerable<T>> GetSubMainCategoryProductsAsync<T>(string categoryId, int page, int itemsPerPage);

        Task<IEnumerable<T>> GetSubCategoryProductsAsync<T>(string categoryId, int page, int itemsPerPage);

        Task<int> GetSubMainCategoryProductsCountAsync(string categoryId);

        Task<int> GetSubCategoryProductsCountAsync(string categoryId);

        Task<T> GetProductDetails<T>(string productId);
    }
}
