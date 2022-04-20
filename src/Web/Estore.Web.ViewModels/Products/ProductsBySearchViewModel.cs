namespace Estore.Web.ViewModels.Products
{
	using System.Collections.Generic;
	using System.Linq;

	public class ProductsBySearchViewModel
	{
		public string Keyword { get; set; }

		public int ProductsCount => this.Products.Count();

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
