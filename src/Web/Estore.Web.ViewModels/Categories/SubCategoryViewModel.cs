namespace Estore.Web.ViewModels.Categories
{
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class SubCategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
    }
}
