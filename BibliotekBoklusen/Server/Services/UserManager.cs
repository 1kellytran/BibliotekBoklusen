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
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserManager(SignInManager<ApplicationUser> signInManager, AppDbContext context, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> GetCurrentUser(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }
        public async Task DeleteUserFromAuthDbContext(string email)
        {
            var user = _signInManager.UserManager.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                await _signInManager.UserManager.DeleteAsync(user);
            }
        }
        public async Task<ServiceResponse<List<User>>> SearchForMembers(string searchText)
        {
            var response = new ServiceResponse<List<User>>
            {
                Data = await FindUserBySearchText(searchText)
            };
            return response;
        }

        private async Task<List<User>> FindUserBySearchText(string searchText)
        {
            var result = await _context.Users
                         .Where(u => u.FirstName.ToLower().Contains(searchText.ToLower()) ||
                         u.LastName.ToLower().Contains(searchText.ToLower())).ToListAsync();
            return result;
        }

        public async Task DeleteUserFromDb(int id)
        {
            var userDb = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(userDb);
            await _context.SaveChangesAsync();

            await DeleteUserFromAuthDbContext(userDb.Email);
        }
    }
}

