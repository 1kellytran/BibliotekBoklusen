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

        public async Task <List<Product>> GetAllProducts()
        {
            List<Product> products = new();

            products = await _httpClient.GetFromJsonAsync<List<Product>>("api/product");

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/product/{id}");
        }

        public async Task CreateProduct(Product productToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/products", productToAdd);
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/product/UpdateProduct/{id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/product/DeleteProduct/{id}");
        }
  
        public IList<string> Types => new List<string>
        {
            new string("Film"),
            new string("Bok"),
            new string("E-bok"),
            new string("Ljudbok")

        };

        // ***** SEMINAR *****
        public async Task <List<Seminarium>> GetAllSeminars()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Seminarium>>("api/seminar/GetAllSeminars");
            if(result != null || result.Count == 0)
            {
                return result;
            }
            return null;
        }

        public async Task<Seminarium> GetSeminarById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Seminarium>("api/seminar/GetSeminarById");
        }

        public async Task CreateSeminar(Seminarium seminar)
        {
            await _httpClient.PostAsJsonAsync<Seminarium>("api/seminar/CreateSeminar", seminar);
        }

        public async Task UpdateSeminar(int id, Seminarium seminar)
        {
            await _httpClient.PutAsJsonAsync<Seminarium>($"api/seminar/UpdateSeminar/{id}", seminar);
        }

        public async Task DeleteSeminar(int id)
        {
            await _httpClient.DeleteAsync($"api/seminar/DeleteSeminar/{id}");
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<Creator>> SearchProducts(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
