namespace Estore.Web.ViewModels.Carts
{
    using System.Collections.Generic;
    using System.Linq;

    public class CartDetailsViewModel
    {
        public IEnumerable<CartProductViewModel> OrderedProducts { get; set; }

        public decimal? TotalAmount
            => this.OrderedProducts != null ? this.OrderedProducts.Sum(o => o.TotalPerProduct) : 0;
    }
}
