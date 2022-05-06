namespace BibliotekBoklusen.Client.Services
{
    public interface IDataManager
    {
        // ***** PRODUCT *****
        Task<List<ProductCreatorModel>> GetAllProducts();
        Task<ProductCreatorModel> GetProductById(int id);
        Task CreateProduct(ProductModel product, CreatorModel creator);
        Task UpdateProduct(int id, ProductModel product);
        Task DeleteProduct(int id);

        // ***** SEMINAR *****
        Task<List<SeminariumModel>> GetAllSeminars();
        Task<SeminariumModel> GetSeminarById(int id);
        Task CreateSeminar(SeminariumModel seminar);
        Task UpdateSeminar(int id, SeminariumModel seminar);
        Task DeleteSeminar(int id);
    }
}