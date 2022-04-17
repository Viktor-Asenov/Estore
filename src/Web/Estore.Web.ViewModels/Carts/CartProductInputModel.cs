namespace Estore.Web.ViewModels.Carts
{
    using System.ComponentModel.DataAnnotations;

    public class CartProductInputModel
    {
        [Required]
        public string ProductId { get; set; }

        [Range(1, 10)]
        public int Quantity { get; set; }
    }
}
