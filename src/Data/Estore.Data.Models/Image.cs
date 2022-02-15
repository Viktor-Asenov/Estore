namespace Estore.Data.Models
{
    using System;

    using Estore.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
