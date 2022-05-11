using System.Net.Http.Json;

namespace BibliotekBoklusen.Client.Services
{
    public class TestManager : ITestManager
    {
        private readonly HttpClient _httpClient;

        public TestManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> CreateProduct(ProductModel productToAdd)
        {
            var result = await _httpClient.PostAsJsonAsync("api/test/createproduct", productToAdd);
            if(result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
