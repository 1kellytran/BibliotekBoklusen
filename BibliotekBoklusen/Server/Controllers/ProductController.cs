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

        [HttpGet]
        public async Task<List<ProductModel>> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ProductModel> GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productToAdd)
        {
            _context.Products.Add(productToAdd);
            await _context.SaveChangesAsync();

            return Ok("Product has been added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductModel productToUpdate)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            product.Title = productToUpdate.Title;
            product.Type = productToUpdate.Type;
            product.CategoryId = productToUpdate.CategoryId;
            product.PublishYear = productToUpdate.PublishYear;
            product.CopiesOwned = productToUpdate.CopiesOwned;

            await _context.SaveChangesAsync();

            return Ok("Product has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok("Product has been deleted");
        }
    }
}
