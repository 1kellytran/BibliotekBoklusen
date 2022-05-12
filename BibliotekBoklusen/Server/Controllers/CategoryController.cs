using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        //Get all categories
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var categoryList = _context.Categories.ToList();

            if (categoryList == null)
            {
                return BadRequest("No products found");
            }

            return Ok(categoryList);
        }

    }
}
