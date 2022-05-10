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

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            List<CategoryModel> categories = new();

            categories = await _httpClient.GetFromJsonAsync<List<CategoryModel>>("api/product/GetAllCategories");

            return categories;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductModel>($"api/product/{id}");
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
        public IList<string> Types => new List<string>
        {
            new string("Film"),
            new string("Bok"),
            new string("E-bok"),
            new string("Ljudbok")

        };   
    }
}
