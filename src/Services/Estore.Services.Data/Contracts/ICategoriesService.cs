namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetMainCategoriesAsync<T>();

        IQueryable<T> GetSubMainCategories<T>(string parentCategoryId);

        IQueryable<T> GetSubSubMainCategories<T>(string parentCategoryId);

        IQueryable<T> GetAllSubCategories<T>();

        Task<string> GetNameAsync(string categoryId);
    }
}
