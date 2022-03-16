namespace Estore.Web.ViewModels.ViewComponents
{
    using System.Collections.Generic;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class MainCategoryMenuViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubMainCategoryMenuViewModel> SubMainCategories { get; set; }
    }
}
