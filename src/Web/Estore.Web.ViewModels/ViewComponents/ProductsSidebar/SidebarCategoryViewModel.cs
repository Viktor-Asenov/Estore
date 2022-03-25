namespace Estore.Web.ViewModels.ViewComponents.ProductsSidebar
{
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class SidebarCategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int CategoryProductsCount { get; set; }
    }
}
