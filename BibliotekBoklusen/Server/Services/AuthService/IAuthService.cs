namespace BibliotekBoklusen.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
    }
}
