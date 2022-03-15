namespace Estore.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class MainCategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubMainCategoryViewModel> SubMainCategories { get; set; }
    }
}
