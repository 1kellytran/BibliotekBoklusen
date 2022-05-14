namespace BibliotekBoklusen.Client.Services
{
    public class ReservationManager : IReservationManager
    {
        private readonly HttpClient _httpClient;

        public ReservationManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = await _httpClient.GetFromJsonAsync<List<Reservation>>("api/reservations");
            if (reservations == null)
            {
                return null;
            }

            return reservations;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var reservation = await _httpClient.GetFromJsonAsync<Reservation>($"api/reservations/{id}");
            if (reservation == null)
            {
                return null;
            }

            return reservation;
        }

        public async Task<string> AddReservation(Reservation reservation)
        {
            var result = await _httpClient.PostAsJsonAsync("api/reservations", reservation);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }

            return null;
        }

        public async Task UpdateReservation(Reservation reservationToUpdate)
        {
            await _httpClient.PutAsJsonAsync($"api/reservations/{reservationToUpdate.Id}", reservationToUpdate);

        }
        public async Task DeleteReservationAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/reservations/{id}");
        }
    }
}
