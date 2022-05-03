﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
        {
            //var creator = _context.Products.Include(d => d.Creators.Where(p=>p.));
            var products = _context.Products.Include(p => p.Category).ToList();

            if(products == null)
            {
                return BadRequest("No products found");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return BadRequest("There is no product with that ID");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreatorModel productToAdd)
        {
            var creator= _context.Creators.ToList();
            
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
