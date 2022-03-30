namespace Estore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Estore.Data.Common.Models;

    public class Color : BaseModel<string>
    {
        public Color()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ColorProducts = new HashSet<ColorProduct>();
        }

        public string Name { get; set; }

        public virtual ICollection<ColorProduct> ColorProducts { get; set; }
    }
}
