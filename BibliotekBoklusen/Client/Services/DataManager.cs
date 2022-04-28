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

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductModel>($"api/product/{id}");
        }

        public async Task CreateProduct(ProductModel product)
        {
            await _httpClient.PostAsJsonAsync("api/product", product);
        }

        public async Task UpdateProduct(int id, ProductModel product)
        {
            await _httpClient.PutAsJsonAsync("api/product/UpdateProduct", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/product/DeleteProduct/{id}");
        }
    }
}
