namespace Estore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Estore.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string RemoteUrl { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
