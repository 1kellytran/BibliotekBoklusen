namespace BibliotekBoklusen.Client.Services
{
    public interface ISearchManager
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        string Message { get; set; }
        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
