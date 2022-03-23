namespace Estore.Web.ViewModels.Categories
{
    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class BreadcrumbViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ParentCategoryId { get; set; }

        public BreadcrumbViewModel ParentCategory { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, BreadcrumbViewModel>()
                .ForPath(bvm => bvm.ParentCategory.Id, opt =>
                    opt.MapFrom(c => c.ParentCategory.Id))
                .ForPath(bvm => bvm.ParentCategory.Name, opt =>
                    opt.MapFrom(c => c.ParentCategory.Name))
                .ForPath(bvm => bvm.ParentCategory.ParentCategoryId, opt =>
                    opt.MapFrom(c => c.ParentCategory.ParentCategoryId));
        }
    }
}
