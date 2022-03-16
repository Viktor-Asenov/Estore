namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IQueryable<T> GetMainCategories<T>();

        IQueryable<T> GetSubMainCategories<T>(string parentCategoryId);

        IQueryable<T> GetSubCategories<T>(string parentCategoryId);
    }
}
