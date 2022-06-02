using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BibliotekBoklusen.Server.Services
{
    public interface IUserService
    {

        Task<List<User>> GetAllUser();
        Task<User> GetUser(int id);
        Task<User> GetCurrentUser(string userEmail);
        Task<ServiceResponse<User>> UpdateUser(UpdatedUserDto model, int id);
        Task<ServiceResponse<string>> ChangePassword(PasswordDto editPassword);
        Task<ServiceResponse<string>> DeleteUserFromDb(int id);
        Task DeleteUserFromAuthDbContext(string email);
        Task<List<User>> GetEmployees();
        Task<List<User>> SearchUsers(string searchText);

    }
}
