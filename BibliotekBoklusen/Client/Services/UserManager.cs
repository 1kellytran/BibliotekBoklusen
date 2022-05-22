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
        public async Task<string> ChangePassword(PasswordDto editPassword)
        {
            var result = await _http.PutAsJsonAsync($"api/user/ChangePassword", editPassword);
            if (result.IsSuccessStatusCode)
            {
                return "Lösenordet har ändrats";
            }
            return "Försök igen";
        }

        public async Task DeleteUser(int id)
        {
            await _http.DeleteAsync($"api/user/{id}");
        }

        public async Task<List<User>> GetAllUser()
        {
            var result = await _http.GetFromJsonAsync<List<User>>($"api/user/getallusers");

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

        public async Task UpdateUserinformation(UpdatedUserDto model, int id)
        {
            await _http.PutAsJsonAsync($"api/user/{id}", model);
        }

        public async Task<List<User>> GetUsersBySearch(string searchText)
        {
          return await _http.GetFromJsonAsync<List<User>>($"api/user/usersbysearch?searchText={searchText}");
        }

        public async Task<List<User>> GetEmployees()
        {
            return await _http.GetFromJsonAsync<List<User>>("api/authenticate");
        }
    }
}
