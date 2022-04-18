namespace Estore.Web.ViewModels.Products
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class ProductInCategoryViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductInCategoryViewModel>()
                .ForMember(pvm => pvm.ImageUrl, opt =>
                    opt.MapFrom(p => p.Images.FirstOrDefault().RemoteUrl));
        }
    }
}
