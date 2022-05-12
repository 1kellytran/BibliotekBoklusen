namespace BibliotekBoklusen.Server.Services.ProductService
{
    public interface IProductService
    {
        
        Task<ServiceResponse<List<ProductModel>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
    }
}
