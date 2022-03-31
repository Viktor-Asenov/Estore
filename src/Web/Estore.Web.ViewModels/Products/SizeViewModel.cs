namespace Estore.Web.ViewModels.Products
{
    using System;

    using AutoMapper;
    using Estore.Services.Mapping;

    public class SizeViewModel : IMapFrom<Enum>, IHaveCustomMappings
    {
        public string Value { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Enum, SizeViewModel>()
                .ForMember(svm => svm.Value, opt =>
                    opt.MapFrom(s => s.ToString()));
        }
    }
}
