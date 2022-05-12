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

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> Get()
        {
            var categoryList = _context.Categories.ToList();

            if (categoryList == null)
            {
                return BadRequest("No products found");
            }

            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryModel categoryToAdd)
        {
            var productExists = _context.Categories
                .FirstOrDefault(p => p.CategoryName.ToLower() == categoryToAdd.CategoryName.ToLower());

            if (productExists == null)
            {
                _context.Categories.Add(categoryToAdd);
                await _context.SaveChangesAsync();
                return Ok(categoryToAdd.CategoryName);
            }
            return BadRequest(categoryToAdd.CategoryName);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryModel newCategoryValues)
        {
            var categoryToChange = await _context.Categories.FindAsync(id);
            if (categoryToChange == null)
                return NotFound();

            categoryToChange.CategoryName = newCategoryValues.CategoryName;
            categoryToChange.isChecked = newCategoryValues.isChecked;

            _context.Update(categoryToChange);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete == null)
                return NotFound();

            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
