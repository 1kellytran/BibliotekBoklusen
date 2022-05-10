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

        public async Task UpdateProduct(int id, ProductCreatorModel product)
        {
            await _httpClient.PutAsJsonAsync($"api/product/UpdateProduct/{id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/product/DeleteProduct/{id}");
        }

        // ***** SEMINAR *****
        public async Task <List<SeminariumModel>> GetAllSeminars()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SeminariumModel>>("api/seminar/GetAllSeminars");
            if(result != null || result.Count == 0)
            {
                return result;
            }
            return null;
        }

        public async Task<SeminariumModel> GetSeminarById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SeminariumModel>("api/seminar/GetSeminarById");
        }

        public async Task CreateSeminar(SeminariumModel seminar)
        {
            await _httpClient.PostAsJsonAsync<SeminariumModel>("api/seminar/CreateSeminar", seminar);
        }

        public async Task UpdateSeminar(int id, SeminariumModel seminar)
        {
            await _httpClient.PutAsJsonAsync<SeminariumModel>($"api/seminar/UpdateSeminar/{id}", seminar);
        }

        public async Task DeleteSeminar(int id)
        {
            await _httpClient.DeleteAsync($"api/seminar/DeleteSeminar/{id}");
        }

        // ***** SEARCH *****
        public async Task<List<ProductCreatorModel>> SearchProducts(string searchText)
        {
            return await _httpClient.GetFromJsonAsync<List<ProductCreatorModel>>($"api/Product/SearchProducts/{searchText}");
        }
    }
}
