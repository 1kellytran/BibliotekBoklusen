namespace BibliotekBoklusen.Server.Services.AuthenticateManager
{
    public interface IAuthenticateManager
    {
        Task<ServiceResponse<string>> Login(LoginDto userLogin);
    }
}
