namespace Estore.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class SubMainCategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<SubCategoryViewModel> SubCategories { get; set; }
    }
}
