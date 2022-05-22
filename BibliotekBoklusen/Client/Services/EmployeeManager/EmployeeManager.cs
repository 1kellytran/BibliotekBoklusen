namespace BibliotekBoklusen.Client.Services.EmployeeManager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly HttpClient _httpClient;

        public EmployeeManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task AddEmployee(int id, User employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("api/employees");
        }

        public Task UpdateEmployee(int id, User employee)
        {
            throw new NotImplementedException();
        }
    }
}
