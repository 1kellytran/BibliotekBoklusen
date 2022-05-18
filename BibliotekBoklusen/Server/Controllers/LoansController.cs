using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILoanService _loanService;

        public LoansController(AppDbContext context, ILoanService loanService)
        {
            _context = context;
            _loanService = loanService;
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
            var loan = _context.Loans.FirstOrDefault(s => s.Id == id);

            if (loan == null)
            {
                return NotFound("There is no loan with that ID");
            }
            return Ok(loan);
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> CreateLoan([FromRoute]int productId,[FromBody]int userId)
        {
            Loan loan= await _loanService.CreateLoan(productId, userId);
            await _context.Loans.AddAsync(loan);
            _context.SaveChangesAsync();
            
            //_loanService.SetBoolProductCopy();
            
            _context.SaveChangesAsync();

            if (loan == null)
            {
                return NotFound("Error");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = _context.Loans.Where(x => x.Id == id).FirstOrDefault();
           
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

            var loan = _context.Loans.FirstOrDefault(x => x.Id == loanToUpdate.Id);
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
