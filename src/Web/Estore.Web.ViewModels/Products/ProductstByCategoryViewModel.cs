namespace Estore.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Tags;

    public class ProductstByCategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string CategoryImage { get; set; }

        public IEnumerable<ProductInCategoryViewModel> CategoryProducts { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public int PageNumber { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, ProductstByCategoryViewModel>()
                .ForMember(pvm => pvm.CategoryImage, opt =>
                    opt.MapFrom(c => c.Images.FirstOrDefault().RemoteUrl));
        }
    }
}
