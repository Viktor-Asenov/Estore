namespace Estore.Web.ViewModels.ViewComponents.Orders
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrdersDetailsViewModel
    {
        public IEnumerable<OrderedProductViewModel> OrderedProducts { get; set; }

        public decimal? TotalAmount
            => this.OrderedProducts != null ? this.OrderedProducts.Sum(o => o.TotalPerProduct) : 0;

        public int? OrderedProductsCount
            => this.OrderedProducts != null ? this.OrderedProducts.Count() : 0;
    }
}
