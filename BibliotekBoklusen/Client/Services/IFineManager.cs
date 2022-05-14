
namespace BibliotekBoklusen.Client.Services
{
    public interface IFineManager
    {
        Task<string> Addfine(Fine fine);
        Task DeleteFineAsync(int id);
        Task<List<Fine>> GetAllFinesAsync();
        Task<Fine> GetFineByIdAsync(int id);
        Task UpdateFine(Fine fineToUpdate);
    }
}