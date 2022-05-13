
namespace BibliotekBoklusen.Client.Services
{
    public interface ISeminarManager
    {
        Task CreateSeminar(Seminarium seminar);
        Task DeleteSeminar(int id);
        Task<List<Seminarium>> GetAllSeminars();
        Task<Seminarium> GetSeminarById(int id);
        Task UpdateSeminar(int id, Seminarium seminar);
    }
}