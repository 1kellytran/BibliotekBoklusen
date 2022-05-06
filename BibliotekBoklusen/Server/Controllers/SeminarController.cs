﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeminarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeminariumModel>>> GetAllSeminars()
        {
            var seminar = _context.Seminariums.ToList();

            if (seminar == null)
            {
                return NotFound("There are no seminars");
            }
            return Ok(seminar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeminariumModel>> GetSeminarById(int id)
        {
            var seminar = _context.Seminariums.FirstOrDefault(s => s.Id == id);

            if (seminar == null)
            {
                return NotFound("There is no seminar with that ID");
            }
            return Ok(seminar);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeminar([FromBody] SeminariumModel seminarToAdd)
        {
            _context.Seminariums.Add(seminarToAdd);
            await _context.SaveChangesAsync();

            return Ok("Seminar has been added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeminar(int id, [FromBody] SeminariumModel seminarToUpdate)
        {
            var seminar = _context.Seminariums.FirstOrDefault(s => s.Id == id);

            if(seminar != null)
            {
                seminar.Title = seminarToUpdate.Title;
                seminar.FirstName = seminarToUpdate.FirstName;
                seminar.LastName = seminarToUpdate.LastName;
                seminar.DayAndTime = seminarToUpdate.DayAndTime;

                await _context.SaveChangesAsync();
                return Ok("Seminar has been updated");
            }
            return BadRequest("There is no seminar with that ID");            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeminar(int id)
        {
            var seminar = _context.Seminariums.FirstOrDefault(s => s.Id == id);

            if(seminar != null)
            {
                _context.Seminariums.Remove(seminar);

                await _context.SaveChangesAsync();

                return Ok("Seminar has been deleted");
            }
            return BadRequest("There is no seminar with that ID");
        }
    }
}