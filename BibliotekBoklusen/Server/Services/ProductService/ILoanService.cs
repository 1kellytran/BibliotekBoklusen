
namespace BibliotekBoklusen.Server.Services.ProductService
{
    public interface ILoanService
    {
        Task<Loan> CreateLoan(int ProductId, int UserId);
        
    }
}