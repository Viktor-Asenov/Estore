﻿namespace Estore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Estore.Data.Common.Models;

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
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int ItemApplyDiscount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<WishList> Favorites { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
