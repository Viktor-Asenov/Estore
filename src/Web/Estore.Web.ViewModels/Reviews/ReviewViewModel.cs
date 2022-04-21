namespace Estore.Web.ViewModels.Reviews
{
    using System;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

	public class ReviewViewModel : IMapFrom<Review>
    {
		public string Author { get; set; }

        public string Content { get; set; }

		public DateTime CreatedOn { get; set; }
	}
}
