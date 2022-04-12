namespace Estore.Web.ViewModels.Wishlists
{
    using System;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;

    public class WishlistProductViewModel : IMapFrom<Wishlist>, IHaveCustomMappings
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductDescription { get; set; }

        public DateTime AddedOn { get; set; }

        public string ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Wishlist, WishlistProductViewModel>()
                .ForMember(wm => wm.AddedOn, opt =>
                    opt.MapFrom(w => w.CreatedOn));
        }
    }
}