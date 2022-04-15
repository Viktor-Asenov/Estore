namespace Estore.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Estore.Web.ViewModels.Tags;
    using Microsoft.EntityFrameworkCore;

    public class TagsService : ITagsService
    {
        private readonly ApplicationDbContext context;

        public TagsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllTagsAsync<T>()
        {
            var tags = this.context.Tags
                .To<T>()
                .ToListAsync();

            return await tags;
        }

        public async Task<IEnumerable<TagProductViewModel>> GetProductsByTagAsync(string tagId, int page, int itemsPerPage)
        {
            var tag = await this.context.Tags
                .FirstOrDefaultAsync(t => t.Id == tagId);

            if (tag == null)
            {
                throw new NullReferenceException();
            }

            var TEST = this.context.ProductTags
                .Where(pt => pt.TagId == tag.Id)
                .Include(pt => pt.Product)
                .To<TagProductViewModel>()
                .ToList();

            var tagProducts = await this.context.ProductTags
                .Where(pt => pt.TagId == tag.Id)
                .Include(pt => pt.Product)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<TagProductViewModel>()
                .ToListAsync();

            return tagProducts;
        }

        public async Task<string> GetNameAsync(string tagId)
        {
            var tag = await this.context.Tags
                .FirstOrDefaultAsync(t => t.Id == tagId);

            if (tag == null)
            {
                throw new ArgumentNullException();
            }

            return tag.Name;
        }

        public async Task<int> GetTagProductsCountAsync(string tagId)
        {
            var tagProducts = await this.context.ProductTags
                .Where(pt => pt.TagId == tagId)
                .ToListAsync();

            if (tagProducts == null)
            {
                throw new ArgumentNullException();
            }

            return tagProducts.Count;
        }
    }
}
