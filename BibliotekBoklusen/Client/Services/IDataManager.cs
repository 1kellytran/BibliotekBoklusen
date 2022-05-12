namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        // ***** PRODUCT *****
        Task<List<ProductCreatorModel>> GetAllProducts();
        Task<ProductCreatorModel> GetProductById(int id);
        Task CreateProduct(ProductModel product);
        Task UpdateProduct(int id, ProductCreatorModel product);
        Task DeleteProduct(int id);
        Task<List<CategoryModel>> GetAllCategories();
        IList<string> Types => new List<string>();

        // ***** SEMINAR *****
        Task<List<SeminariumModel>> GetAllSeminars();
        Task<SeminariumModel> GetSeminarById(int id);
        Task CreateSeminar(SeminariumModel seminar);
        Task UpdateSeminar(int id, SeminariumModel seminar);
        Task DeleteSeminar(int id);

        // ***** SEARCH *****
        //Task<List<ProductCreatorModel>> SearchProducts(string searchText);
        event Action ProductsChanged;
        List<ProductModel> Products { get; set; }
        string Message { get; set; }

        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);


    }
}