using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> GetAllReservations()
        {
            var reservations = _context.Reservations.ToList();

            if (reservations == null || reservations.Count <= 0)
            {
                return NotFound("There are no reservations");
            }
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(s => s.Id == id);

            if (reservation == null)
            {
                return NotFound("There is no reservation with that Id");
            }
            return Ok(reservation);
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> CreateReservation([FromRoute] int productId, [FromBody] int userId)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationDate = DateTime.Now;
            reservation.UserId = userId;
            reservation.ProductId = productId;
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            if (reservation == null)
            {
                return NotFound("Error");
            }
            return Ok(reservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = _context.Reservations.Where(x => x.Id == id).FirstOrDefault();

            if (reservation == null)
            {
                return BadRequest("There is no reservation with that ID");
            }
            else
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();

            }
            return Ok("Reservation has been deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation([FromBody] Reservation reservationToUpdate)
        {

            var reservation = _context.Reservations.FirstOrDefault(x => x.Id == reservationToUpdate.Id);
            if (reservation != null)
            {
                reservation.ReservationDate = reservation.ReservationDate.AddDays(14);
                await _context.SaveChangesAsync();

                return Ok("Reservation has been updated");
            }
            return NotFound();

        }
    }
}
