using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCopiesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductCopiesController(AppDbContext context)
        {
            _context = context;
        }
   
       
        [HttpGet("{dinmamma}")]

        public async Task<ActionResult<List<Product>>> GetAllLoans()
        {
            var allLoans = _context.productCopies.Where(p =>p.IsLoaned ==false).GroupBy(p => p.ProductId).Select(g => g.OrderBy(p => p.Id).FirstOrDefault()).ToList();/*_context.productCopies.Where(p => p.IsLoaned == false).Take(1).ToList();*/
            List<Product> availableProducts = new();

            foreach (var productId in allLoans)
            {
                var availableProduct = _context.Products.Include(p => p.Creators)
                .Include(c => c.Category).FirstOrDefault(p => p.Id == productId.ProductId);
                availableProducts.Add(availableProduct);
            }


            return availableProducts;

        }

       
    }
}
