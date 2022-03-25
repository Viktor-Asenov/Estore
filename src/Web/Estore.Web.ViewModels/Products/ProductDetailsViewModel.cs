namespace Estore.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(pvm => pvm.Images, opt =>
                    opt.MapFrom(c => c.Images));
        }
    }
}
