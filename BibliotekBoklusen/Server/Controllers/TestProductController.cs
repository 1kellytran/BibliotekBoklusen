using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TestProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<TestProductController>
       

        // POST api/<TestProductController>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            //var product = new Product { Title = "haryypotter", PublishYear = 1976, Type = "Bok" };
            //var category = new Category { CategoryName = "Deckare" };
            //var creator = new Creator { FirstName = "Astrid", LastName = "Lindgren" };

            //product.Creators.Add(creator);
            //product.Category.Add(category);

            //await _context.Products.AddAsync(product);

            //await _context.SaveChangesAsync();  

            //var result = _context.Products.Include(p => p.Creators)
            //    .Include(c =>c.Category).ToList();


            //return result;

            var result = _context.Categories.Include(c => c.Products).ToList();
            return result;


        }

        // PUT api/<TestProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
