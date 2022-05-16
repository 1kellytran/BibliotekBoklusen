namespace BibliotekBoklusen.Client.Services
{
    public interface IUserManager
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUser(int id);
        Task UpdateUserinformation(UpdatedUserDto model);
        Task ChangePassword(PasswordDto editPassword);
        Task DeleteUser(string email);
        Task<string> Login(LoginDto model);
        Task<string> Register(RegisterDto model);
        Task RegisterAdmin(RegisterDto model);
        Task<User> GetCurrentUser(string userEmail);

    }
}
