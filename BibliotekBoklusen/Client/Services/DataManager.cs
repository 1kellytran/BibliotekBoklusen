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

        public async Task <List<ProductCreatorModel>> GetAllProducts()
        {
            List<ProductCreatorModel> products = new();

            products = await _httpClient.GetFromJsonAsync<List<ProductCreatorModel>>("api/product/GetAllProducts");

            return products;
        }

        public async Task<ProductCreatorModel> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductCreatorModel>($"api/product/GetProductById/{id}");
        }

        public async Task CreateProduct(ProductModel product, CreatorModel creator)
        {
            ProductCreatorModel productCreator = new();
            productCreator.Product = product;
            productCreator.Creator = creator;

            await _httpClient.PostAsJsonAsync("api/product", productCreator);
        }

        public async Task UpdateProduct(int id, ProductModel product)
        {
            await _httpClient.PutAsJsonAsync($"api/product/UpdateProduct/{id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/product/DeleteProduct/{id}");
        }
    }
}
