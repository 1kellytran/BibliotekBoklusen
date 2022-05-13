namespace BibliotekBoklusen.Client.Services
{
    public interface ICategoryManager
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);
        Task<string> AddCategory(CategoryModel category);
        Task UpdateCategory(CategoryModel category);
        Task DeleteCategoryAsync(int id);
    }
}
