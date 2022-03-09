namespace Estore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Estore.Data.Common.Models;
    using Estore.Data.Models.Enumerations;

    public class Product : BaseDeletableModel<string>
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.Orders = new HashSet<Order>();
            this.Images = new HashSet<Image>();
            this.Favorites = new HashSet<WishList>();
            this.Reviews = new HashSet<Review>();
            this.ProductTags = new HashSet<ProductTag>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public int ItemApplyDiscount { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public ICollection<Color> Colors { get; set; }

        [NotMapped]
        public ICollection<Size> Sizes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<WishList> Favorites { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
