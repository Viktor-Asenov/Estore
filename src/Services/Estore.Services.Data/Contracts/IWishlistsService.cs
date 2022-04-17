namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistsService
    {
        Task<IEnumerable<T>> GetWishedProductsAsync<T>(string userId);

        Task<string> AddProductToWishlistAsync(string userId, string productId);
    }
}
