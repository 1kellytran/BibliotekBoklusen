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

        // ***** SEMINAR *****
        Task<List<Seminarium>> GetAllSeminars();
        Task<Seminarium> GetSeminarById(int id);
        Task CreateSeminar(Seminarium seminar);
        Task UpdateSeminar(int id, Seminarium seminar);
        Task DeleteSeminar(int id);

        // ***** SEARCH *****
        //Task<List<ProductCreatorModel>> SearchProducts(string searchText);
        event Action ProductsChanged;
        List<ProductModel> Products { get; set; }
        string Message { get; set; }

        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);


        Task<List<Creator>> SearchProducts(string searchText);
    }
}