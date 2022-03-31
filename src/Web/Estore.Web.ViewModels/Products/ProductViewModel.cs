namespace Estore.Web.ViewModels.Products
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public string DiscountedPrice
            => string.Format("{0:0.00}", this.Price -= this.Price * (this.Discount / 100) ?? this.Price);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(rvm => rvm.ImageUrl, opt =>
                    opt.MapFrom(p => p.Images.FirstOrDefault().RemoteUrl));
        }
    }
}
