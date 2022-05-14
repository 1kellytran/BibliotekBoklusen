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
                return NotFound("There are no loans");
            }
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoansById(int id)
        {
            var loan = _context.Loans.FirstOrDefault(s => s.CopyId == id);

            if (loan == null)
            {
                return NotFound("There is no loan with that ID");
            }
            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan()
        {
            Loan loan = new Loan();
            loan.LoanDate = DateTime.Now;
            loan.ReturnDate = DateTime.Now.AddDays(14);
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            
            if (loan == null)
            {
                return NotFound("Error");
            }
            return Ok(loan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = _context.Loans.Where(x => x.CopyId == id).FirstOrDefault();
           
            if (loan == null)
            {
                return BadRequest("There is no loan with that ID");
            }
            else
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();

            }
            return Ok("Loan has been deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLoan([FromBody] Loan loanToUpdate)
        {

            var loan = _context.Loans.FirstOrDefault(x => x.CopyId == loanToUpdate.CopyId);
            if (loan != null)
            {
                loan.ReturnDate = loan.ReturnDate.AddDays(14);
                await _context.SaveChangesAsync();

                return Ok("Loan has been updated");
            }
            return NotFound();

        }

    }
}
