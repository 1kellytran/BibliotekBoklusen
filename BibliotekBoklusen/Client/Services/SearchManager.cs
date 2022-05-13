namespace BibliotekBoklusen.Client.Services
{
    public class SearchManager: ISearchManager
    {
        private readonly HttpClient _httpClient;

        public SearchManager(HttpClient httpClient)
        {
         
            _httpClient = httpClient;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products..";

        public event Action ProductsChanged;

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient
              .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;

            }
            if (Products.Count == 0) Message = "No products found.";
            ProductsChanged?.Invoke();
        }
    }
}
