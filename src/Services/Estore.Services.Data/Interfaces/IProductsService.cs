namespace Estore.Services.Data.Interfaces
{
    public interface IProductsService<T>
    {
        T GetAllByCategory(string categoryId);
    }
}
