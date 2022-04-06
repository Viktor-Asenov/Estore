namespace Estore.Web.ViewModels.ViewComponents.Cart
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class OrderedProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, OrderedProductViewModel>()
                .ForMember(ovm => ovm.ImageUrl, opt =>
                    opt.MapFrom(c => c.Images.FirstOrDefault().RemoteUrl));
        }
    }
}
