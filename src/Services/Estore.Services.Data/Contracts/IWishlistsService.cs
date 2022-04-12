namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistsService
    {
        Task<IEnumerable<T>> GetWishedProducts<T>(string userId);
    }
}
