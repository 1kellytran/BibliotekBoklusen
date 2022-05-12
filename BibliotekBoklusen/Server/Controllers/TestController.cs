using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productToAdd)
        {

            var result = _context.Products.FirstOrDefault(p => p.Title.ToLower() == productToAdd.Title.ToLower() && p.Type == productToAdd.Type);

            if (result == null)
            {
                _context.Products.Add(productToAdd);
                await _context.SaveChangesAsync();
                return Ok("Product has been added");
            }
            return BadRequest("Product already exists");
            //if (productToAdd == null)
            //    return BadRequest();

            ////Checks if product already exists in db
            //var productExists = _context.Products.FirstOrDefault(p => p.Title.ToLower() == productToAdd.Title.ToLower());

            //if (productExists == null)
            //{
            //    productExists = new Product
            //    {
            //        Title = productToAdd.Title,
            //        PublishYear = productToAdd.PublishYear,
            //        Type = productToAdd.Type
            //    };
            //}

            //var productCreators = new List<ProductCreatorModel>();

            //foreach (var creator in productToAdd.Creators)
            //{
            //    //Checks if creator already exists in db
            //    var creatorExists = _context.Creators.FirstOrDefault
            //        (c => c.FirstName.ToLower() == creator.FirstName.ToLower()
            //        && c.LastName.ToLower() == creator.LastName.ToLower());
            //    var productCreator = new ProductCreatorModel();

            //    productCreator.Product = productExists;
            //    _ = creatorExists == null ? productCreator.Creator = creator : productCreator.Creator = creatorExists;
            //    productCreators.Add(productCreator);
            //}

            //var productCategories = new List<ProductCategory>();
            //foreach (var category in productToAdd.Category)
            //{
            //    //Checks if category already exists in db
            //    var categoryExists = _context.Categories.FirstOrDefault
            //        (c => c.CategoryName.ToLower() == category.CategoryName.ToLower());

            //    var productCategory = new ProductCategory();
            //    productCategory.Product = productExists;
            //    _ = categoryExists == null ? productCategory.Category = category : productCategory.Category = categoryExists;
            //    productCategories.Add(productCategory);
            //}

            //await _context.ProductCreator.AddRangeAsync(productCreators);
            //await _context.ProductCategories.AddRangeAsync(productCategories);
            //var result = await _context.SaveChangesAsync();
            //var name = productExists.Title;
            //return Ok(name);

        }

    }
}
