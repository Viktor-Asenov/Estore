namespace Estore.Web.ViewModels.Wishlists
{
    using System.Collections.Generic;

    public class WishlistViewModel
    {
        public IEnumerable<WishlistProductViewModel> WishProducts { get; set; }
    }
}
