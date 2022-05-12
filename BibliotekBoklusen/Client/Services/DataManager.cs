﻿using System.Net.Http.Json;

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
        public async Task <List<ProductCreatorModel>> GetAllProducts()
        {
            List<ProductCreatorModel> products = new();

            products = await _httpClient.GetFromJsonAsync<List<ProductCreatorModel>>("api/product");

            return products;
        }

        public async Task<ProductCreatorModel> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductCreatorModel>($"api/product/{id}");
        }

        public async Task CreateProduct(ProductModel productToAdd)
        {
            await _httpClient.PostAsJsonAsync("api/products", productToAdd);
        }

        public async Task UpdateProduct(int id, ProductCreatorModel product)
        {
            await _httpClient.PutAsJsonAsync($"api/product/UpdateProduct/{id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/product/DeleteProduct/{id}");
        }
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            List<CategoryModel> categories = new();

            categories = await _httpClient.GetFromJsonAsync<List<CategoryModel>>("api/category");

            return categories;
        }
        public IList<string> Types => new List<string>
        {
            new string("Film"),
            new string("Bok"),
            new string("E-bok"),
            new string("Ljudbok")

        };

        

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
        //public async Task<List<ProductCreatorModel>> SearchProducts(string searchText)
        //{
        //    return await _httpClient.GetFromJsonAsync<List<ProductCreatorModel>>($"api/Product/SearchProducts/{searchText}");

        //}
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public string Message { get; set; } = "Loading Products..";
        public async Task SearchProducts(string searchText)
        {
            var result = await _httpClient
                 .GetFromJsonAsync<ServiceResponse<List<ProductModel>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;

            }
            if (Products.Count == 0) Message = "No products found.";
            ProductsChanged?.Invoke();
        }


        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient
               .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }


    }
    
}

