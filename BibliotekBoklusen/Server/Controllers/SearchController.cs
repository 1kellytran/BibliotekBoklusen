using BibliotekBoklusen.Server.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekBoklusen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService _productService;

        public SearchController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("Search/{searchText}")]
        public async Task<ActionResult<List<ProductCreatorModel>>> SearchProducts(string searchText)
        {
            return Ok(await _productService.SearchProducts(searchText));
        }
    }
}
