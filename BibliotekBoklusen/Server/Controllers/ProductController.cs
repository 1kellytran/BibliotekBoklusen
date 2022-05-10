using BibliotekBoklusen.Server.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<ProductCreatorModel>>> GetAllProducts()
        {
            var productCreatorDb = _context.ProductCreator.Include(p => p.Product).ThenInclude(c => c.Category).ToList();

            List<ProductCreatorModel> productCreatorList = new();

            foreach (var item in productCreatorDb)
            {
                ProductCreatorModel productCreator = new();

                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                var creator = _context.Creators.FirstOrDefault(c => c.Id == item.CreatorId);

                creator.ProductCreators = null;
                product.ProductCreators = null;

                productCreator.Creator = creator;
                productCreator.Product = product;
                productCreator.ProductId = item.ProductId;
                productCreator.CreatorId = item.CreatorId;
                productCreatorList.Add(productCreator);
            }

            if (productCreatorList == null)
            {
                return BadRequest("No products found");
            }
            return Ok(productCreatorList);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            var categories =  _context.Categories.ToList();
            if (categories==null)
            {
                return BadRequest("No categories");
            }
            return Ok(categories);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCreatorModel>> GetProductById(int id)
        {
            var product = _context.Products.Include(p =>p.Category).FirstOrDefault(p => p.Id == id);
            var productCreator= _context.ProductCreator.Where(pc => pc.ProductId == id).FirstOrDefault();
            var creator = _context.Creators.Where(c => c.Id == productCreator.CreatorId).FirstOrDefault();

            ProductCreatorModel model = new();
            model.Creator = creator;
            model.Product = product;
            model.CreatorId = creator.Id;
            model.ProductId = product.Id;
            model.Creator.ProductCreators = null;
            model.Product.ProductCreators = null;

            if (model == null)
            {
                return BadRequest("There is no product with that ID");
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreatorModel productToAdd)
        {
            var creator = _context.Creators.ToList();

            foreach (var item in creator)
            {
                if (item.FirstName == productToAdd.Creator.FirstName && item.LastName == productToAdd.Creator.LastName)
                {
                    productToAdd.Creator = item;
                }
            }

            _context.ProductCreator.Add(productToAdd);
            await _context.SaveChangesAsync();

            return Ok("Product has been added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductCreatorModel productToUpdate)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            product.Title = productToUpdate.Product.Title;
            product.Type = productToUpdate.Product.Type;
            product.CategoryId = productToUpdate.Product.CategoryId;
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

      
    }
}
