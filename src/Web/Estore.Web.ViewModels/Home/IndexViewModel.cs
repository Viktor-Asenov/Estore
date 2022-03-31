namespace Estore.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Estore.Web.ViewModels.Products;

    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> LatestProducts { get; set; }

        public IEnumerable<ProductViewModel> MostDiscountedProducts { get; set; }
    }
}
