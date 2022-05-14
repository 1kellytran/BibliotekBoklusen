namespace BibliotekBoklusen.Client.Services
{
    public class FineManager : IFineManager
    {
        private readonly HttpClient _httpClient;

        public FineManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Fine>> GetAllFinesAsync()
        {
            var fines = await _httpClient.GetFromJsonAsync<List<Fine>>("api/fines");
            if (fines == null)
            {
                return null;
            }

            return fines;
        }

        public async Task<Fine> GetFineByIdAsync(int id)
        {
            var fine = await _httpClient.GetFromJsonAsync<Fine>($"api/fines/{id}");
            if (fine == null)
            {
                return null;
            }

            return fine;
        }

        public async Task<string> Addfine(Fine fine)
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
        public async Task DeleteFineAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/fines/{id}");
        }

    }
}
