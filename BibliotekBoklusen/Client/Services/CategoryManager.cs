
namespace BibliotekBoklusen.Client.Services
{
    public class CategoryManager : ICategoryManager
    {
        private readonly HttpClient _httpClient;

        public CategoryManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<CategoryModel>>("api/category");
            if (categoryList == null)
                return null;
            return categoryList;
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var category = await _httpClient.GetFromJsonAsync<CategoryModel>($"api/category/{id}");
            if (category == null)
                return null;
            return category;
        }
        public async Task<string> AddCategory(CategoryModel category)
        {
            var result = await _httpClient.PostAsJsonAsync("api/category", category);
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();
            return null;
        }
        public async Task UpdateCategory(CategoryModel category)
        {
            await _httpClient.PutAsJsonAsync($"api/category/{category.Id}", category);
        }
        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/category/{id}");
        }
    }
}
