namespace Estore.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Tags;

    public class ProductstByCategoryViewModel
    {
        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }

        public IEnumerable<ProductInCategoryViewModel> CategoryProducts { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public int CategoriesProductsCount => this.CategoryProducts.Count();

        public int PageNumber { get; set; }
    }
}
