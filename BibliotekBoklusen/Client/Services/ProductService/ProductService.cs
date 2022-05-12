using System.Net.Http.Json;

namespace BibliotekBoklusen.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        
    }
}
