using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BibliotekBoklusen.Server.Services
{
    public interface IUserManager
    {
        Task<User> GetCurrentUser(string userEmail);
        Task<ServiceResponse<List<User>>> SearchForMembers(string searchText);
        Task DeleteUserFromDb(int userId);
        Task DeleteUserFromAuthDbContext(string email);
        Task<List<User>> GetEmployees();
    }
}
