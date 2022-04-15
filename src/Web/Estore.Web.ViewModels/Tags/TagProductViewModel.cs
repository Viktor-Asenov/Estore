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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductTag, TagProductViewModel>()
                .ForMember(tpvm => tpvm.Id, opt =>
                    opt.MapFrom(pt => pt.Product.Id))
                .ForMember(tpvm => tpvm.Name, opt =>
                    opt.MapFrom(pt => pt.Product.Name))
                .ForMember(tpvm => tpvm.Description, opt =>
                    opt.MapFrom(pt => pt.Product.Description))
                .ForMember(tpvm => tpvm.ImageUrl, opt =>
                    opt.MapFrom(pt => pt.Product.Images.FirstOrDefault().RemoteUrl))
                .ForMember(tpvm => tpvm.Price, opt =>
                    opt.MapFrom(pt => pt.Product.Price));
        }
    }
}
