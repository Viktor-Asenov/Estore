namespace Estore.Web.ViewModels.Tags
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class TagProductViewModel : IMapFrom<ProductTag>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public decimal? DiscountedPrice
            => this.Price -= this.Price * (this.Discount / 100) ?? this.Price;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductTag, TagProductViewModel>()
                .ForMember(tpvm => tpvm.ImageUrl, opt =>
                    opt.MapFrom(pt => pt.Product.Images.FirstOrDefault().RemoteUrl));
        }
    }
}
