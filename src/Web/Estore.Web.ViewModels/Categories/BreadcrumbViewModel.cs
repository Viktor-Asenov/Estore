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
                .ForMember(
                    x => x.ParentCategory,
                    opt => opt.MapFrom(c =>
                        new BreadcrumbViewModel
                        {
                            Id = c.ParentCategory.Id,
                            Name = c.ParentCategory.Name,
                            ParentCategoryId = c.ParentCategory.ParentCategoryId,
                            ParentCategory = new BreadcrumbViewModel
                            {
                                Id = c.ParentCategory.ParentCategory.Id,
                                Name = c.ParentCategory.ParentCategory.Name,
                                ParentCategoryId = c.ParentCategory.ParentCategory.ParentCategoryId,
                            },
                        }));
        }
    }
}
