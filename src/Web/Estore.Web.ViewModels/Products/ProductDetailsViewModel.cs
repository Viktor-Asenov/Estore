namespace Estore.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Data.Models.Enumerations;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Products.Enums;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<ColorType> Colors { get; set; }

        public IEnumerable<Measure> Measures { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public IEnumerable<RelatedProductViewModel> RelatedProducts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Color, ColorType>();
            configuration.CreateMap<Size, Measure>();

            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(pvm => pvm.Images, opt =>
                    opt.MapFrom(p => p.Images))
                .ForMember(pvm => pvm.Colors, opt =>
                    opt.MapFrom(p => p.Colors.ToArray()))
                .ForMember(pvm => pvm.Measures, opt =>
                    opt.MapFrom(p => p.Sizes.ToArray()));
        }
    }
}
