namespace Estore.Web.ViewModels.Reviews
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewInputModel
    {
        public string ProductId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Author { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(300)]
        public string Content { get; set; }
    }
}
