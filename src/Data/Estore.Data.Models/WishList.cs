namespace Estore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Wishlist
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
