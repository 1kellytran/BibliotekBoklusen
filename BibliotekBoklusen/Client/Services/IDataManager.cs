namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        Task CreateProduct(ProductModel product);
        Task UpdateProduct(int id, ProductModel product);
        Task DeleteProduct(int id);
    }
}