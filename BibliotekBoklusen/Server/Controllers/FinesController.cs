using Microsoft.AspNetCore.Mvc;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FinesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fine>>> GetAllFines()
        {
            var fines = _context.Fines.ToList();

            if (fines == null || fines.Count <= 0)
            {
                return NotFound("There are no fines");
            }
            return Ok(fines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fine>> GetFineById(int id)
        {
            var fine = _context.Fines.Where(s => s.Id == id);

            if (fine == null)
            {
                return NotFound("There is no fine with that ID");
            }
            return Ok(fine);
        }

        [HttpGet("{id}")]
        [Route("GetUserFine")]
        public async Task<ActionResult<Fine>> GetUserFine(int id)
        {
            var userFine = _context.Fines.Where(u => u.Id == id).ToList();

            if(userFine != null)
            {
                return Ok(userFine);
            }
            return NotFound("NAJ");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFine()
        {
            Fine fine = new Fine();
            fine.FineDate = DateTime.Today;
            fine.FineAmount = 2300;

            _context.Fines.Add(fine);
            await _context.SaveChangesAsync();

            if (fine == null)
            {
                return NotFound("Error");
            }
            return Ok(fine);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFine([FromBody] Fine fineToUpdate)
        {
            var fine = _context.Fines.FirstOrDefault(x => x.Id == fineToUpdate.Id);
            if (fine != null)
            {
                fine.FineDate = DateTime.Today;
                fine.FineAmount = fineToUpdate.FineAmount;
                await _context.SaveChangesAsync();

                return Ok("Fine has been updated");
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFine(int id)
        {
            var fine = _context.Fines.Where(x => x.Id == id).FirstOrDefault();

            if (fine == null)
            {
                return BadRequest("There is no fine with that ID");
            }
            else
            {
                _context.Fines.Remove(fine);
                await _context.SaveChangesAsync();
            }
            return Ok("Fine has been deleted");
        }
    }
}
