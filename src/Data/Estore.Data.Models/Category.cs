﻿namespace Estore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Estore.Data.Common.Models;

    public class Category : BaseDeletableModel<string>
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
