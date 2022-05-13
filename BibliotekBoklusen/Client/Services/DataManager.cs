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

        

        
        

        // ***** SEARCH *****
        //public async Task<List<ProductCreatorModel>> SearchProducts(string searchText)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<ProductCreatorModel>>($"api/Product/SearchProducts/{searchText}");

        //}
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products..";
        List<Product> IDataManager.Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }



        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient
               .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }

        Task<List<Creator>> IDataManager.SearchProducts(string searchText)
        {
            throw new NotImplementedException();
        }
    }
    
}

