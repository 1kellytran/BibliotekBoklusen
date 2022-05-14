
namespace BibliotekBoklusen.Client.Services
{
    public interface IReservationManager
    {
        Task<string> AddReservation(Reservation reservation);
        Task DeleteReservationAsync(int id);
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task UpdateReservation(Reservation reservationToUpdate);
    }
}