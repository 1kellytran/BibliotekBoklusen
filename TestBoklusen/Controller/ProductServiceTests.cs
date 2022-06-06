using BibliotekBoklusen.Server.Services.ProductService;
using BibliotekBoklusen.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Test.Controller
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductService> _mockRepo;
        private readonly ProductsController _controller;
        public ProductServiceTests()
        {
            _mockRepo=new Mock<IProductService>();
            _controller = new ProductsController(_mockRepo.Object);
        }

        [Fact]
        public void GetAllProducts_ActionExecutes_ReturnCorrectNumberOfProducts()
        {
             _mockRepo.Setup(repo => repo.GetAllProducts()).ReturnsAsync(new List<Product> { new Product(), new Product() });

            var result = _controller.GetAllProducts();
            var taskResult = Assert.IsType<Task<ActionResult<List<Product>>>>(result);
            var actionResult = Assert.IsType<ActionResult<List<Product>>>(result.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var productList = Assert.IsType<List<Product>>(objectResult.Value);
            Assert.Equal(2, productList.Count);

        }

        [Fact]
        public void GetProduct_ActionExecutes_GetProductByIdCorrectContent()
        {
            _mockRepo.Setup(repo => repo.GetProductById(1))
                .ReturnsAsync(new Product() { Id = 1, Title = "Pippi", NumberOfCopiesOwned = 2, Published = DateTime.Now, Type = ProductType.Film, Creators = new(), Category = new() });
            var result = _controller.GetProductById(1);
            var taskResult = Assert.IsType<Task<ActionResult<Product>>>(result);
            var actionResult = Assert.IsType<ActionResult<Product>>(taskResult.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var product = Assert.IsType<Product>(objectResult.Value);

            Assert.Equal(1, product.Id);
            Assert.Equal("Pippi", product.Title);
            Assert.Equal(2, product.NumberOfCopiesOwned);
        }

        [Fact]
        public void Create_ActionExecutes_GetCorrectResponse()
        {
            var product = new Product { Id = 1, Title = "Pippi", NumberOfCopiesOwned = 2, Published = DateTime.Now, Type = ProductType.Film, Creators = new(), Category = new() };
        
            var result = _controller.CreateProduct(product);
            var taskResult = Assert.IsType<Task<ActionResult>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(taskResult.Result);
        }

        [Fact]
        public void Delete_ActionExecutes_GetCorrectResponse()
        {
            var product = new Product { Id = 1, Title = "Pippi", NumberOfCopiesOwned = 2, Published = DateTime.Now, Type = ProductType.Film, Creators = new(), Category = new() };
            var result=_controller.DeleteProduct(product.Id);
            var taskResult = Assert.IsType<Task<ActionResult<string>>>(result);
            var content = Assert.IsType<ActionResult<string>>(taskResult.Result);
            Assert.IsType<OkObjectResult>(content.Result);
        }

        [Fact]
        public async Task DeleteUserFromDb_VerifyDeleteUser()
        {
            var userId = 2;
            _mockRepo.Setup(u => u.DeleteProduct(userId));
          
            await _mockRepo.Object.DeleteProduct(userId);

            _mockRepo.Verify(u => u.DeleteProduct(userId));
        }
        [Fact]
        public void Put_ActionExecutes_ReturnOkObjectResult()
        {
            var product = new Product { Id = 1, Title = "Pippi", NumberOfCopiesOwned = 2, Published = DateTime.Now, Type = ProductType.Film, Creators = new(), Category = new() };
           var result= _controller.UpdateProduct(1, product);
            var taskResult = Assert.IsType<Task<ActionResult>>(result);
            Assert.IsType<OkObjectResult>(taskResult.Result);
        }

        //    [Fact]
        //    public void Put_ActionExecutes_ChangeProduct()
        //    {
        //        Product product = null;
        //        int idNr = 1;
        //        _mockRepo.Setup(r => r.UpdateProduct(idNr,It.IsAny<Product>()))
        //      .Callback<Product>(x => product = x);

        //        var updatedProduct = new Product
        //        {
        //            Title = "Emil",
        //            NumberOfCopiesOwned = 3,
        //            Type = ProductType.Film
        //        };
        //        _controller.UpdateProduct(1,updatedProduct);
        //        _mockRepo.Verify(x => x.UpdateProduct(idNr,It.IsAny<Product>()), Times.Once);
        //        Assert.Equal(product.Title, updatedProduct.Title);
        //        Assert.Equal(product.Title, updatedProduct.Title);
        //        Assert.Equal(product.Type, updatedProduct.Type);

        //    }
    }
}
