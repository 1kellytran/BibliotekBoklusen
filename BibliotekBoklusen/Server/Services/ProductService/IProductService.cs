namespace BibliotekBoklusen.Server.Services.ProductService
{
    public interface IProductService
    {
       
        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task CreateProductCopies(Product product);
    }
}
