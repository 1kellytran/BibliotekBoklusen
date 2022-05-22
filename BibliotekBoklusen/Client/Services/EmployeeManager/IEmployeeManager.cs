﻿namespace BibliotekBoklusen.Client.Services.EmployeeManager
{
    public interface IEmployeeManager
    {
        Task<List<User>> GetEmployees();
        Task<User> GetEmployee(int employeeId);
        Task AddEmployee(int id, User employee);
        Task UpdateEmployee(int id, User employee);
        Task DeleteEmployee(int id);
    }
}
