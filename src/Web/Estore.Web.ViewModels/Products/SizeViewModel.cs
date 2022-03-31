namespace Estore.Web.ViewModels.Products
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class SizeViewModel : IMapFrom<string>
    {
        public string Value { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Product, SizeViewModel>()
        //        .ForMember(svm => svm.Value, opt =>
        //            opt.MapFrom(p => p.Sizes.FirstOrDefault().ToString()));
        //}
    }
}
