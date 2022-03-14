namespace Estore.Web.ViewModels.Tags
{
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class TagViewModel : IMapFrom<Tag>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
