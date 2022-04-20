namespace Estore.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;

    public class ProductstByCategoryViewModel
    {
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int CategoriesProductsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int CurrentPageItemsNumber
            => this.ItemsPerPage * this.PageNumber > this.CategoriesProductsCount
            ? this.CategoriesProductsCount : this.ItemsPerPage * this.PageNumber;

        public int PagesCount => (int)Math.Ceiling((double)this.CategoriesProductsCount / this.ItemsPerPage);

        public IEnumerable<ProductViewModel> CategoryProducts { get; set; }
    }
}
