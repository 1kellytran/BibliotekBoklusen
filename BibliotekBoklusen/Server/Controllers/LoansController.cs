using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LoansController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{

        //}
    }
}
