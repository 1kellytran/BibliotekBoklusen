using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BibliotekBoklusen.Server.Services
{
    public interface IUserManager
    {
        Task<User> GetCurrentUser(string userEmail)
    }
}
