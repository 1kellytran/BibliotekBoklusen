using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoansController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Loan>>> GetAllLoans()
        {
            var loans = _context.Loans.ToList();

            if (loans == null || loans.Count <= 0)
            {
                return NotFound("There are no seminars");
            }
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seminarium>> GetLoansById(int id)
        {
            var loan = _context.Loans.FirstOrDefault(s => s.CopyId == id);

            if (loan == null)
            {
                return NotFound("There is no loan with that ID");
            }
            return Ok(loan);
        }

    }
}
