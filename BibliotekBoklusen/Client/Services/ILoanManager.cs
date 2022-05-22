
namespace BibliotekBoklusen.Client.Services
{
    public interface ILoanManager
    {
        Task<string> AddLoan(int productId, int userId);
        Task<List<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task ReturnLoanAsync(int id);
        Task UpdateLoan(Loan loanToUpdate);
        Task<List<Loan>> GetLoansByUserId(int userId);

        Task<List<Product>> GetTopProducts();
    }
}