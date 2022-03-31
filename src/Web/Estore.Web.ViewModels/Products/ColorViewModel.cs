namespace Estore.Web.ViewModels.Products
{
    using System;

    using AutoMapper;
    using Estore.Services.Mapping;

    public class ColorViewModel : IMapFrom<Enum>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Enum, ColorViewModel>()
                .ForPath(cvm => cvm.Name, opt =>
                    opt.MapFrom(c => c.ToString()));
        }
    }
}
