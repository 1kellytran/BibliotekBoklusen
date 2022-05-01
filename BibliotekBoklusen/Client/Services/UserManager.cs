using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BibliotekBoklusen.Client.Services
{
    public class UserManager : IUserManager
    {
        private readonly HttpClient _http;

        public UserManager(HttpClient http)
        {
            _http = http;
        }
        public async Task ChangePassword(PasswordDto editPassword)
        {
            await _http.PutAsJsonAsync($"api/users/ChangePassword",editPassword);
        }

        public async Task DeleteUser(string email)
        {
            await _http.DeleteAsync($"api/user{email}");
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var result = await _http.GetFromJsonAsync<List<UserModel>>($"api/user/GetAllUser");

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<UserModel> GetUser(int id)
        {
            //($"api/user/{id}")
            var result = await _http.GetFromJsonAsync<UserModel>($"api/user/{id}");

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task Login(LoginDto model)
        {
            await _http.PostAsJsonAsync($"api/Authenticate/login", model);
        }

        public async Task Register(RegisterDto model)
        {
            await _http.PostAsJsonAsync("api/Authenticate/register", model);
        }

        public async Task RegisterAdmin(RegisterDto model)
        {
            await _http.PostAsJsonAsync("api/Authenticate/register-admin", model);
        }

        public async Task UpdateUserinformation(UpdatedUserDto model)
        {
            await _http.PutAsJsonAsync("api/user", model);
        }

        
    }
}
