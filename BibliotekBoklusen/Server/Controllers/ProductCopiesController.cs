using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

       
        [HttpGet("{id}")]
        public async Task <List<ProductCopy>> GetProductCopy(int id)
        {
            var prodcop=  _context.productCopies.Where(pc => pc.ProductId == id).ToList();
           
            if (prodcop !=null)
            {
                return prodcop;
            }
            else
            {
                return null;
            }
            
        }

       
    }
}
