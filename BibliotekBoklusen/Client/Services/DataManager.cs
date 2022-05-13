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

        public event Action ProductsChanged;

        public async Task <List<Product>> GetAllProducts()

        {
            List<Product> products = new();

            products = await _httpClient.GetFromJsonAsync<List<Product>>("api/products");

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }

        public async Task CreateProduct(Product productToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/products", productToAdd);
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/products/{id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/products/{id}");
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IList<string> Types => new List<string>
        {
            new string("Film"),
            new string("Bok"),
            new string("E-bok"),
            new string("Ljudbok")
        };
    }    
}

