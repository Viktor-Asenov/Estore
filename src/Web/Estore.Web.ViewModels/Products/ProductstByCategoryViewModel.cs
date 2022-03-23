namespace Estore.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Estore.Data.Models;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Categories;
    using Estore.Web.ViewModels.Tags;

    public class ProductstByCategoryViewModel
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }

        public int CategoriesProductsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.CategoriesProductsCount / this.ItemsPerPage);

        public BreadcrumbViewModel Breadcrumb { get; set; }

        public IEnumerable<ProductInCategoryViewModel> CategoryProducts { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}
