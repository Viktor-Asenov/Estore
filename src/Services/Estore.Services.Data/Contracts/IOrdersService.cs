namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        Task<string> AddProductInOrdersAsync(string userId, string productId, int quantity);

        Task DeleteProductFromOrdersAsync(string productId);

        Task<IEnumerable<T>> GetOrderedProductsAsync<T>(string userId);

        Task Checkout(string userId);
    }
}
