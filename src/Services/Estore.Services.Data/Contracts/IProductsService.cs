namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<IEnumerable<T>> GetAllByCategory<T>(string categoryId, int page, int itemsPerPage);

        Task<int> GetCount(string categoryId);
    }
}
