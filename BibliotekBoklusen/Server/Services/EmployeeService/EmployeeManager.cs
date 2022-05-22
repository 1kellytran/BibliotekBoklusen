using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BibliotekBoklusen.Server.Services.EmployeeService
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly AuthDbContext _authDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeManager(AuthDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _authDbContext = context;
            _roleManager = roleManager;
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

        //public Task<List<User>> GetEmployees()
        //{
        //    var employeeRole = _roleManager.FindByNameAsync("Librarian");

        //    var employees = _authDbContext.
                
        //}

        public Task UpdateEmployee(int id, User employee)
        {
            throw new NotImplementedException();
        }
    }
}
