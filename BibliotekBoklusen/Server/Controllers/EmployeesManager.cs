using BibliotekBoklusen.Server.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManager : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesManager(IEmployeeManager employeeManager)
        {
           _employeeManager = employeeManager;
        }
        //[HttpGet]
        //public List<User> Get()
        //{
        //   var result = _employeeManager.GetAll();
        //}

        // GET api/<EmployeesManager>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesManager>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesManager>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesManager>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
