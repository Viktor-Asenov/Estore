namespace Estore.Web.ViewModels.ViewComponents.MainMenu
{
    using System.Collections.Generic;

    using Estore.Web.ViewModels.Categories;

    public class MainMenuViewModel
    {
        public IEnumerable<MainCategoryMenuViewModel> MainCategories { get; set; }
    }
}
