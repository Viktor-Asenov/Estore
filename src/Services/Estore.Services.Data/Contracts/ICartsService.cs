namespace Estore.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Estore.Data.Models;

    public interface ICartsService
    {
        Task<string> AddProductInOrdersAsync(string userId, string productId, int quantity);

        Task<Product> CheckIfProductExistAsync(string productId);
    }
}
