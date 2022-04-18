namespace Estore.Web.ViewModels.Tags
{
    using System;
    using System.Collections.Generic;

    using Estore.Web.ViewModels.Categories;

    public class TagProductsViewModel
    {
        public string TagId { get; set; }

        public string TagName { get; set; }

        public int TagProductsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int CurrentPageItemsNumber
            => this.ItemsPerPage * this.PageNumber > this.TagProductsCount
            ? this.TagProductsCount : this.ItemsPerPage * this.PageNumber;

        public int PagesCount => (int)Math.Ceiling((double)this.TagProductsCount / this.ItemsPerPage);

        public IEnumerable<TagProductViewModel> TagProducts { get; set; }
    }
}
