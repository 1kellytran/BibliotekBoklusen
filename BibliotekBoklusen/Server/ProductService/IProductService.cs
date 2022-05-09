namespace BibliotekBoklusen.Server.ProductService
{
    public interface IProductService
    {
        Task<List<ProductCreatorModel>> SearchProducts(string searchText);
    }
}
