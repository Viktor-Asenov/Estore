namespace Estore.Web.ViewModels.ViewComponents
{
    using System.Collections.Generic;

    using Estore.Web.ViewModels.Categories;

    public class MainMenuViewModel
    {
        public IEnumerable<MainCategoryViewModel> MainCategories { get; set; }
    }
}
