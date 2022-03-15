namespace Estore.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Estore.Web.ViewModels.Categories;

    public interface ICategoriesService
    {
        Task<IEnumerable<MainCategoryViewModel>> GetAllMain();

        Task<IEnumerable<SubMainCategoryViewModel>> GetSubMain(string parentCategoryId);

        Task<IEnumerable<SubCategoryViewModel>> GetSub(string parentCategoryId);
    }
}
