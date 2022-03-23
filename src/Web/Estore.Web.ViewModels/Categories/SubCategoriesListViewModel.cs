namespace Estore.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    public class SubCategoriesListViewModel
    {
        public string ParentCategoryName { get; set; }

        public IEnumerable<CategoryViewModel> SubCategories { get; set; }
    }
}
