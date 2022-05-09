namespace BibliotekBoklusen.Server.ProductService
{
    public interface IProductService
    {
        Task<List<ProductCreatorModel>> SearchProduct(string searchText);
    }
}
