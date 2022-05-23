namespace BibliotekBoklusen.Client.Services
{
    public class FineManager : IFineManager
    {
        private readonly HttpClient _httpClient;
        public FineManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Fine>> GetAllFines()
        {
            var fines = await _httpClient.GetFromJsonAsync<List<Fine>>("api/fines");
            if (fines == null)
            {
                return null;
            }
            return fines;
        }

        public async Task<Fine> GetFineById(int id)
        {
            var fine = await _httpClient.GetFromJsonAsync<Fine>($"api/fines/{id}");
            if (fine == null)
            {
                return null;
            }
            return fine;
        }

        public async Task<Fine> GetUserFine(int id)
        {
            var fine = await _httpClient.GetFromJsonAsync<Fine>($"api/fines/GetUserFine/{id}");
            if(fine != null)
            {
                return fine;
            }
            return null;
        }

        public async Task<string> AddFine(Fine fine)
        {
            var result = await _httpClient.PostAsJsonAsync("api/fines", fine);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            return null;
        }

        public async Task UpdateFine(Fine fineToUpdate)
        {
            await _httpClient.PutAsJsonAsync($"api/fines/{fineToUpdate.Id}", fineToUpdate);
        }

        public async Task DeleteFine(int id)
        {
            await _httpClient.DeleteAsync($"api/fines/{id}");
        }
    }
}
