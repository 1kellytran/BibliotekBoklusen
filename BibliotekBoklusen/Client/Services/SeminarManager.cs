﻿namespace BibliotekBoklusen.Client.Services
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
            
            var seminars = await _httpClient.GetFromJsonAsync<List<Seminarium>>("api/seminars");

            return seminars;
        }

        public async Task<Seminarium> GetSeminarById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Seminarium>($"api/seminars/{id}");
        }

        public async Task<string> CreateSeminar(Seminarium seminar)
        {
            var result = _httpClient.PostAsJsonAsync<Seminarium>("api/seminars", seminar);
            var message = result.IsCompletedSuccessfully ? $"Seminariet \"{seminar.Title}\" har lagts till" : null;
            return message;
        }

        public async Task UpdateSeminar(int id, Seminarium seminar)
        {
            await _httpClient.PutAsJsonAsync<Seminarium>($"api/seminars/{id}", seminar);
        }

        public async Task DeleteSeminar(int id)
        {
            await _httpClient.DeleteAsync($"api/seminars/{id}");
        }
    }
}
