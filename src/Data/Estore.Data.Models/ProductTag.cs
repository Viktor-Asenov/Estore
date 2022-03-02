namespace Estore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductTag
    {
        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
