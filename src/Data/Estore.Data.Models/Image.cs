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
        public string Url { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
