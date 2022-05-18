namespace BibliotekBoklusen.Client.Services
{
    public class ProductCopyManager : IProductCopyManager
    {
        private readonly HttpClient _httpClient;

        public ProductCopyManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProductCopy>> GetProductCopyById(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<ProductCopy>>($"api/productcopies/{id}");
        }
    }
}
