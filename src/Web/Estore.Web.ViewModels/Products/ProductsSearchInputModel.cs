namespace Estore.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

	public class ProductsSearchInputModel
	{
		[Required]
		[MinLength(3)]
		[MaxLength(20)]
		public string Keyword { get; set; }
	}
}
