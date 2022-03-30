namespace Estore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ColorProduct
    {
        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string ColorId { get; set; }

        public virtual Color Color { get; set; }
    }
}