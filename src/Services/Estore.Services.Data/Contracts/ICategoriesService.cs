namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetMainCategoriesAsync<T>();

        IQueryable<T> GetParentSubMainCategories<T>(string parentCategoryId);

        IQueryable<T> GetParentSubCategories<T>(string parentCategoryId);

        IQueryable<T> GetAllSubCategories<T>();

        Task<string> GetNameAsync(string categoryId);

        Task<string> GetImageAsync(string categoryId);

        Task<T> GetBreadcrumbCategoryAsync<T>(string categoryId);
    }
}
