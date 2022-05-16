using BibliotekBoklusen.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BibliotekBoklusen.Server.Services
{
    public class UserManager : IUserManager
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserManager(SignInManager<ApplicationUser> signInManager, AppDbContext dbContext, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User> GetCurrentUser(string userEmail)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }
    }
}

