namespace Estore.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using Estore.Web.ViewModels.Tags;

    public class ProductstByCategoryViewModel
    {
        public IEnumerable<ProductInCategoryViewModel> CategoryProducts { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public int PageNumber { get; set; }
    }
}
