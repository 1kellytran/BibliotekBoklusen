namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task<List<Category>> GetAllCategories();
        IList<string> Types => new List<string>();
    }
}