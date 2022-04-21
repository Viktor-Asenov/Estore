namespace Estore.Web.ViewModels.Administration.Reviews
{
    using System;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

	public class AdministrationReviewViewModel : IMapFrom<Review>
	{
		public string Id { get; set; }

		public string Author { get; set; }

		public string Content { get; set; }

		public DateTime CreatedOn { get; set; }

		public string ProductId { get; set; }

		public string ProductName { get; set; }
	}
}
