namespace Estore.Web.ViewModels.Products
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class ColorViewModel : IMapFrom<string>
    {
        public string Name { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Product, ColorViewModel>()
        //        .ForPath(cvm => cvm.Name, opt =>
        //            opt.MapFrom(p => p.Colors.FirstOrDefault().ToString()));
        //}
    }
}
