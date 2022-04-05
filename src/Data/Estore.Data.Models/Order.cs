namespace Estore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Required]
        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPerProduct { get; set; }

        public bool IsDiscountGiven { get; set; }
    }
}
