namespace Estore.Web.ViewModels.ViewComponents.Cart
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrdersDetailsViewModel
    {
        public IEnumerable<OrderedProductViewModel> OrderedProducts { get; set; }

        public decimal? TotalAmount { get; set; }

        public int OrderedProductsCount => this.OrderedProducts.Count();
    }
}
