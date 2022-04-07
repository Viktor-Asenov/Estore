namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICartsService
    {
        Task<string> AddProductInOrdersAsync(string userId, string productId, int quantity);

        Task<IEnumerable<T>> GetOrderedProductsAsync<T>(string userId);

        Task<decimal?> GetTotalAmount(string cartId);
    }
}
