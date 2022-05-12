using BibliotekBoklusen.Server.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;

        public ProductsController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
        {
            var productCreatorList = _context.Products.Include(p => p.Creators)
                .Include(c => c.Category).ToList();

            if (productCreatorList == null)
            {
                return BadRequest("No products found");
            }

            return Ok(productCreatorList);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var product = _context.Products.Include(p => p.Creators).Include(c => c.Category).FirstOrDefault(p => p.Id == id);


            if (product == null)
            {
                return BadRequest("There is no product with that ID");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productToAdd)
        {

            var productExists = _context.Products.FirstOrDefault(p => p.Title.ToLower() == productToAdd.Title.ToLower() && p.Type == productToAdd.Type);
            if (productExists == null)
            {
                var category = new CategoryModel { CategoryName = "Superhjältar", isChecked = false };
                var categories = new List<CategoryModel>();
                categories.Add(category);
                var creator = new Creator { FirstName = "astrid", LastName = "lindgren" };
                var creators = new List<Creator>();
                creators.Add(creator);

                var product = new ProductModel()
                {
                    Title = productToAdd.Title,
                    PublishYear = 1986,
                    Type = productToAdd.Type,
                    Category = categories,
                    Creators = creators
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok("Product has been added");
            }
            return BadRequest("Product already exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductCreatorModel productToUpdate)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            product.Title = productToUpdate.Product.Title;
            product.Type = productToUpdate.Product.Type;
            product.PublishYear = productToUpdate.Product.PublishYear;

            await _context.SaveChangesAsync();

            return Ok("Product has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest("There is no product with that ID");
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return Ok("Product has been deleted");
        }

        //[HttpGet]
        //public async Task<ActionResult<List<ProductCreatorModel>>> SearchProducts(string searchText)
        //{
        //    return Ok(await _productService.SearchProducts(searchText));
        //}


        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> SearchProducts(string searchText)
        {
            var result = await _productService.SearchProducts(searchText);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }
    }
}
