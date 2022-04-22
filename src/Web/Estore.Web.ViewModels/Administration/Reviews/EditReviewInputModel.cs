namespace Estore.Web.ViewModels.Administration.Reviews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Estore.Data.Models;
    using Estore.Services.Mapping;

	public class EditReviewInputModel : IMapFrom<Review>
	{
		public string Id { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(25)]
		public string Author { get; set; }

		[Required]
		[MinLength(4)]
		[MaxLength(300)]
		public string Content { get; set; }

		[Display(Name = "Product")]
		public string ProductId { get; set; }

		public IEnumerable<KeyValuePair<string, string>> Products { get; set; }
	}
}
