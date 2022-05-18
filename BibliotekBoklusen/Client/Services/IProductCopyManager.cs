
namespace BibliotekBoklusen.Client.Services
{
    public interface IProductCopyManager
    {
        Task<List<ProductCopy>> GetProductCopyById(int id);
    }
}