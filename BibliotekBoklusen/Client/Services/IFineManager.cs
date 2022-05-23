namespace BibliotekBoklusen.Client.Services
{
    public interface IFineManager
    {
        Task<List<Fine>> GetAllFines();
        Task<Fine> GetFineById(int id);
        Task<Fine> GetUserFine(int id);
        Task<string> AddFine(Fine fine);
        Task UpdateFine(Fine fineToUpdate);
        Task DeleteFine(int id);
    }
}