﻿using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> GetLoansById(int id)
        {

            var productUserHas = _loanService.GetLoansById(id);
            

            if (productUserHas == null)
            {
                return NotFound("There is no loan with that ID");
            }
            return Ok(productUserHas);
        }

        [HttpPost("{productId}")]
        public async Task<ActionResult<string>> CreateLoan([FromRoute]int productId,[FromBody]int userId)
        {
            Loan loan= await _loanService.CreateLoan(productId, userId);

            if (loan !=null)
            {
                await _context.Loans.AddAsync(loan);
                _context.SaveChangesAsync();
                return Ok("Loan har lagts till");
            }
            
            else
            {
                return NotFound("Inga exemplar finns tillgängliga av denna boken");
            }
            
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

        [HttpPut("{productCopyId}")]
        public async Task<IActionResult> ReturnLoan([FromRoute] int productCopyId)
        {
           var response= await _loanService.ReturnLoan(productCopyId);

            if (response)
            {
              
                return Ok("Loan has been updated");
            }
            else
            {
                return NotFound();
            }
            

        }

    }
}
