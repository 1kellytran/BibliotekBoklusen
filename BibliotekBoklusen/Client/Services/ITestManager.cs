namespace BibliotekBoklusen.Client.Services
{
    public interface ITestManager
    {
        Task<string> CreateProduct(ProductModel productToAdd);
    }
}
