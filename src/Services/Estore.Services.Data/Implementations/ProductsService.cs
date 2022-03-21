namespace Estore.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Estore.Data;
    using Estore.Services.Data.Contracts;
    using Estore.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext context;

        public ProductsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllByCategory<T>(string categoryId, int page, int itemsPerPage)
        {
            var categoryProducts = this.context.Products
                    .Where(p => p.Category.ParentCategoryId == categoryId)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync();

            return await categoryProducts;
        }

        public async Task<int> GetCount(string categoryId)
        {
            var subMainCategoryProducts = await this.context.Products
                .Where(p => p.Category.ParentCategoryId == categoryId)
                .ToListAsync();

            return subMainCategoryProducts.Count();
        }
    }
}
