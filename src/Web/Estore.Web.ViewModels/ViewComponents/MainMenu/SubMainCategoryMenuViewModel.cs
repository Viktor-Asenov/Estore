namespace Estore.Web.ViewModels.ViewComponents.MainMenu
{
    using System.Collections.Generic;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class SubMainCategoryMenuViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubCategoryMenuViewModel> SubCategories { get; set; }
    }
}
