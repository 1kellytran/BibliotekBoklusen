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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public async void CreateProduct([FromBody] ProductModel productToAdd)
        {
            _context.Products.Add(productToAdd);
            await _context.SaveChangesAsync();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async void EditProduct([FromQuery] int id, [FromBody] ProductModel productToEdit)
        {
            ProductModel product = new();

            product = _context.Products.FirstOrDefault(x => x.Id == id);

            product.Title = productToEdit.Title;
            product.Type = productToEdit.Type;
            product.Genre = productToEdit.Genre;
            product.PublishYear = productToEdit.PublishYear;
            product.Creators = productToEdit.Creators;
            product.Quantity = productToEdit.Quantity;
            product.Reserved = productToEdit.Reserved;

            await _context.SaveChangesAsync();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            
        }
    }
}
