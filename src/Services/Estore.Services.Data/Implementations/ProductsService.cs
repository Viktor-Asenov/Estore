namespace Estore.Services.Data.Implementations
{
    using Estore.Data.Common.Repositories;
    using Estore.Data.Models;
    using Estore.Services.Data.Interfaces;
    using Estore.Services.Data.Models.Products;

    public class ProductsService : IProductsService<ProductsByCategoryDto>
    {

        public ProductsService()
        {
        }

        public ProductsByCategoryDto GetAllByCategory(string categoryId)
        {
            ProductsByCategoryDto categoryProducts = null;

            return categoryProducts;
        }
    }
}
