
namespace BibliotekBoklusen.Client.Services
{
    public interface ILoanManager
    {
        Task<string> AddLoan(int productId, int userId);
        Task DeleteLoanAsync(int id);
        Task<List<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task UpdateLoan(Loan loanToUpdate);
    }
}