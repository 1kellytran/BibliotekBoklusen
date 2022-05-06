namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        Task<List<ProductCreatorModel>> GetAllProducts();
        Task<ProductCreatorModel> GetProductById(int id);
        Task CreateProduct(ProductModel product, CreatorModel creator);
        Task UpdateProduct(int id, ProductModel product);
        Task DeleteProduct(int id);
    }
}