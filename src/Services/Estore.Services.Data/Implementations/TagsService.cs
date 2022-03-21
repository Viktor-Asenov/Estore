namespace Estore.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
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
    }
}
