﻿using Newtonsoft.Json;
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
            var result = await _http.PostAsJsonAsync($"api/authenticate/login", model);
            if(result.IsSuccessStatusCode)
            {
                var token = result.Content.ReadAsStringAsync();
              if(token != null)
                {
                    await _localStorageService.SetItemAsync("authToken", token);
                }
            }
        }

        public async Task Register(RegisterDto model)
        {
            await _http.PostAsJsonAsync("api/authenticate/register", model);
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
