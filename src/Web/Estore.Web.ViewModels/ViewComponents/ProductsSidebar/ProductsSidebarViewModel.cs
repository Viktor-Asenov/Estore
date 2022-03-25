namespace Estore.Web.ViewModels.ViewComponents.ProductsSidebar
{
    using System.Collections.Generic;

    public class ProductsSidebarViewModel
    {
        public IEnumerable<SidebarCategoryViewModel> Categories { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}
