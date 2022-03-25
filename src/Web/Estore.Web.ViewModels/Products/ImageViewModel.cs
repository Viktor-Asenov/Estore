namespace Estore.Web.ViewModels.Products
{
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string RemoteUrl { get; set; }
    }
}