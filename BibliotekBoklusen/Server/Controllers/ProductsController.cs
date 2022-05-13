﻿using BibliotekBoklusen.Server.Services.ProductService;
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
        public async Task<ActionResult<List<Product>>> GetAllProducts()
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
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = _context.Products.Include(p => p.Creators).Include(c => c.Category).FirstOrDefault(p => p.Id == id);


            if (product == null)
            {
                return BadRequest("There is no product with that ID");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product productToAdd)
        {
            // Kollar om produkten redan finns i db genom titel och typ.
            var productExists = _context.Products.FirstOrDefault(p => p.Title.ToLower() == productToAdd.Title.ToLower() && p.Type == productToAdd.Type);

            if (productExists == null)
            {
                var categoryList = new List<Category>();

                // Kollar om kategorin redan finns i databasen. Lägger då till den i en lista.
                foreach (var category in productToAdd.Category)
                {
                    var categoryExists = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
                    if (categoryExists != null)
                        categoryList.Add(categoryExists);
                    else
                        categoryList.Add(category);
                }
                productToAdd.Category = categoryList;

                var creatorList = new List<Creator>();

                // Kollar om författaren redan finns. Lägger då till den i en ny lista.
                foreach (var creator in productToAdd.Creators)
                {
                    var creatorExists = _context.Creators.FirstOrDefault(c => c.FirstName.ToLower() == creator.FirstName.ToLower() && c.LastName.ToLower() == creator.LastName.ToLower());

                    if (creatorExists != null)
                        creatorList.Add(creatorExists);
                    else
                        creatorList.Add(creator);
                }

                productToAdd.Creators = creatorList;

                _context.Products.Add(productToAdd);
                await _context.SaveChangesAsync();
                return Ok("Product has been added");
            }
            return BadRequest("Product already exists");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product productToUpdate)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                product.Title = productToUpdate.Title;
                product.Type = productToUpdate.Type;
                product.PublishYear = productToUpdate.PublishYear;
                await _context.SaveChangesAsync();

                return Ok("Product has been updated");
            }
            return NotFound();

         
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
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText)
        {
            var result = await _productService.SearchProducts(searchText);
            return Ok(result);
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(result);
        }
    }
}
