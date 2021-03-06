namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Estore.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task<IEnumerable<T>> GetLatestAsync<T>();

        Task<IEnumerable<T>> GetMostDiscountedAsync<T>();

        Task<IEnumerable<T>> GetSubMainCategoryProductsAsync<T>(string categoryId, int page, int itemsPerPage);

        Task<IEnumerable<T>> GetSubCategoryProductsAsync<T>(string categoryId, int page, int itemsPerPage);

        Task<int> GetSubMainCategoryProductsCountAsync(string categoryId);

        Task<int> GetSubCategoryProductsCountAsync(string categoryId);

        Task<ProductDetailsViewModel> GetDetailsAsync(string productId);

        Task<IEnumerable<T>> GetBySearchTermAsync<T>(string keyword);

        Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsKeyValuePairsAsync();
	}
}
