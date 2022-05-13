namespace BibliotekBoklusen.Client.Services
{

    public class LoanManager : ILoanManager
    {
        private readonly HttpClient _httpClient;

        public LoanManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Loan>> GetAllLoansAsync()
        {
            var creators = await _httpClient.GetFromJsonAsync<List<Loan>>("api/loans");
            if (creators == null)
                return null;
            return creators;
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            var creator = await _httpClient.GetFromJsonAsync<Loan>($"api/loans/{id}");
            if (creator == null)
                return null;
            return creator;
        }

        public async Task<string> AddLoan(Loan loan)
        {
            var result = await _httpClient.PostAsJsonAsync("api/loans", loan);
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();
            return null;
        }

        public async Task UpdateLoan(Loan loanToUpdate)
        {
            await _httpClient.PutAsJsonAsync($"api/loans/{loanToUpdate.CopyId}", loanToUpdate);

        }
        public async Task DeleteLoanAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/loans/{id}");
        }







    }

}
