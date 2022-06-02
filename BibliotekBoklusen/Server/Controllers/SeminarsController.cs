using BibliotekBoklusen.Server.Services.SeminarService;
using Microsoft.AspNetCore.Mvc;
namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        private readonly ISeminarManager _seminarManager;

        public SeminarsController(ISeminarManager seminarManager)
        {
            _seminarManager = seminarManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Seminarium>>> GetAllSeminars()
        {
            var seminar = _seminarManager.GetAllSeminars();

            if (seminar == null)
            {
                return NotFound("There are no seminars");
            }
            return Ok(seminar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seminarium>> GetSeminarById(int id)
        {
            var seminar = _seminarManager.GetSeminarById(id);

            if (seminar == null)
            {
                return NotFound("There is no seminar with that ID");
            }
            return Ok(seminar);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeminar([FromBody] Seminarium seminarToAdd)
        {
            if(seminarToAdd != null)
            {
                _seminarManager.CreateSeminar(seminarToAdd);

                return Ok("Seminar has been added");
            }
            return BadRequest("Could not add");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeminar(int id, [FromBody] Seminarium seminarToUpdate)
        {
            var seminar = _seminarManager.UpdateSeminar(id, seminarToUpdate);

            if(seminar != null)
            {
                return Ok("Seminar has been updated");
            }
            return NotFound("There is no seminar with that ID");            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeminar(int id)
        {
            var seminar = _seminarManager.DeleteSeminar(id);

            if(seminar != null)
            {
                return Ok("Seminar has been deleted");
            }
            return NotFound("There is no seminar with that ID");
        }
    }
}
