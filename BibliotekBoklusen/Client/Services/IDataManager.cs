namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        Task CreateProduct(ProductModel product, CreatorModel creator);
        Task UpdateProduct(int id, ProductModel product);
        Task DeleteProduct(int id);
        Task<List<CategoryModel>> GetAllCategories();
        IList<string> Types => new List<string>();


    }
}