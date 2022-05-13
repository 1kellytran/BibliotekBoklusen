
namespace BibliotekBoklusen.Client.Services
{
    public interface ILoanManager
    {
        Task<string> AddLoan(Loan loan);
        Task DeleteLoanAsync(int id);
        Task<List<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task UpdateLoan(Loan loanToUpdate);
    }
}