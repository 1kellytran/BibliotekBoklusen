using System.Net.Http.Json;

namespace BibliotekBoklusen.Client.Services
{
    public class DataManager : IDataManager
    {
        private readonly HttpClient _httpClient;

        public DataManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task <List<ProductModel>> GetAllProducts()
        {
            List<ProductModel> products = new();

            products = await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/product/GetAllProducts");

            return products;
        }
    }
}
