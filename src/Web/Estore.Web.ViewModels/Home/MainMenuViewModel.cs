namespace Estore.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Estore.Web.ViewModels.Categories;

    public class MainMenuViewModel
    {
        public IEnumerable<MainCategoryViewModel> MainCategories { get; set; }

        public IEnumerable<SubMainCategoryViewModel> SubMainCategories { get; set; }

        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}
