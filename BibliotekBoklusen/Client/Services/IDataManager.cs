namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        // ***** PRODUCT *****
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task<List<Category>> GetAllCategories();
        IList<string> Types => new List<string>();

        
       

        // ***** SEARCH *****
        //Task<List<ProductCreatorModel>> SearchProducts(string searchText);
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }

        Task<List<string>> GetProductSearchSuggestions(string searchText);

        Task<List<Creator>> SearchProducts(string searchText);
    }
}