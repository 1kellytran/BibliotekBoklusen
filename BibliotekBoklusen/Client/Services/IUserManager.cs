namespace BibliotekBoklusen.Client.Services
{
    public interface IUserManager
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUser(int id);
        Task UpdateUserinformation(UpdatedUserDto model);
        Task ChangePassword(PasswordDto editPassword);
        Task DeleteUser(string email);
        Task Login(LoginDto model);
        Task Register(RegisterDto model);
        Task RegisterAdmin(RegisterDto model);

    }
}
