namespace Estore.Web.ViewModels.Categories
{
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(cvm => cvm.ImageUrl, opt =>
                    opt.MapFrom(c => c.Images.FirstOrDefault().RemoteUrl));
        }
    }
}
