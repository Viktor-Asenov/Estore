namespace Estore.Web.ViewModels.ViewComponents.Orders
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class OrderedProductViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPerProduct { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, OrderedProductViewModel>()
                .ForMember(ovm => ovm.Id, opt =>
                    opt.MapFrom(o => o.Product.Id))
                .ForMember(ovm => ovm.Name, opt =>
                    opt.MapFrom(o => o.Product.Name))
                .ForMember(ovm => ovm.Price, opt =>
                    opt.MapFrom(o => o.Product.Price));
        }
    }
}
