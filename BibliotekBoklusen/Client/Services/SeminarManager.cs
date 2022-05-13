namespace BibliotekBoklusen.Client.Services
{
    public class SeminarManager : ISeminarManager
    {
        private readonly HttpClient _httpClient;



        public SeminarManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Seminarium>> GetAllSeminars()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Seminarium>>("api/seminar/GetAllSeminars");
            if (result != null || result.Count == 0)
            {
                return result;
            }
            return null;
        }

        public async Task<Seminarium> GetSeminarById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Seminarium>("api/seminar/GetSeminarById");
        }

        public async Task CreateSeminar(Seminarium seminar)
        {
            await _httpClient.PostAsJsonAsync<Seminarium>("api/seminar/CreateSeminar", seminar);
        }

        public async Task UpdateSeminar(int id, Seminarium seminar)
        {
            await _httpClient.PutAsJsonAsync<Seminarium>($"api/seminar/UpdateSeminar/{id}", seminar);
        }

        public async Task DeleteSeminar(int id)
        {
            await _httpClient.DeleteAsync($"api/seminar/DeleteSeminar/{id}");
        }
    }
}
