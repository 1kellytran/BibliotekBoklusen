using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
  
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<ProductModel>> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductModel> GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productToAdd)
        {
            _context.Products.Add(productToAdd);
            await _context.SaveChangesAsync();

            return Ok("Product has been added");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromQuery] int id, [FromBody] ProductModel productToUpdate)
        {
            ProductModel product = new();

            product = _context.Products.FirstOrDefault(x => x.Id == id);

            product.Title = productToUpdate.Title;
            //product.Type = productToUpdate.Type;
            //product.Genre = productToUpdate.Genre;
            //product.PublishYear = productToUpdate.PublishYear;
            //product.Creators = productToUpdate.Creators;
            //product.Quantity = productToUpdate.Quantity;
            //product.Reserved = productToUpdate.Reserved;

            await _context.SaveChangesAsync();

            return Ok("Product has been updated");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            ProductModel product = new();

            product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok("Product has been deleted");
        }
    }
}
