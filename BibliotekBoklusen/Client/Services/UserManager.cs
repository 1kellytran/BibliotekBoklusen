using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BibliotekBoklusen.Client.Services
{
    public class UserManager : IUserManager
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorageService;

        public UserManager(HttpClient http, ILocalStorageService localStorageService)
        {
            _http = http;
            _localStorageService = localStorageService;
        }
        public async Task ChangePassword(PasswordDto editPassword)
        {
            await _http.PutAsJsonAsync($"api/users/ChangePassword", editPassword);
        }

        public async Task DeleteUser(int id)
        {
            await _http.DeleteAsync($"api/user/{id}");
        }

        public async Task<List<User>> GetAllUser()
        {
            var result = await _http.GetFromJsonAsync<List<User>>($"api/user/GetAllUser");

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<User> GetUser(int id)
        {
            //($"api/user/{id}")
            var result = await _http.GetFromJsonAsync<User>($"api/user/{id}");

            if (result != null)
            {
                return result;
            }
            return null;
        }


        public async Task<User> GetCurrentUser(string userEmail)
        {
            //($"api/user/{id}")
            var result = await _http.GetFromJsonAsync<User>($"api/user/currentuser?userEmail={userEmail}");
            return result;

  
        }

        public async Task<string> Login(LoginDto model)
        {
            var result = await _http.PostAsJsonAsync($"api/authenticate/login", model);

            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();
                if (token != null)
                {
                    await _localStorageService.SetItemAsync("authToken", token);
                    await _localStorageService.SetItemAsync("email", model.Email);
                    return null;
                }
            }
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> Register(RegisterDto model)
        {
            var result = await _http.PostAsJsonAsync("api/authenticate/register", model);

            if (result.IsSuccessStatusCode)
            {
                return null;
            }
            return await result.Content.ReadAsStringAsync();
        }

        public async Task RegisterAdmin(RegisterDto model)
        {
            await _http.PostAsJsonAsync("api/authenticate/register-admin", model);
        }

        public async Task UpdateUserinformation(UpdatedUserDto model)
        {
            await _http.PutAsJsonAsync("api/user", model);
        }


    }
}
