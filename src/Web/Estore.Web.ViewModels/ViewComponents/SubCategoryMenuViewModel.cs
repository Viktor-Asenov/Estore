namespace Estore.Web.ViewModels.ViewComponents
{
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class SubCategoryMenuViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
