namespace Estore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<IEnumerable<T>> GetAllByCategory<T>(int page, int itemsPerPage, string categoryId);

        Task<IEnumerable<T>> GetAllTags<T>();
    }
}
