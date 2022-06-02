using BibliotekBoklusen.Server.Services.ProductService;
using BibliotekBoklusen.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;

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
        public void GetAllProducts_ActionExecutes_ReturnsTaskForGetAllProducts()
        {
            var result = _controller.GetAllProducts();
            Assert.IsType<Task<ActionResult<List<Product>>>>(result);
        }

        [Fact]
        public void GetAllProducts_ActionExecutes_ReturnsExactNumberOfProducts()
        {
             _mockRepo.Setup(repo => repo.GetAllProducts()).ReturnsAsync(new List<Product> { new Product(), new Product() });

            var result = _controller.GetAllProducts();
            var viewResult = Assert.IsType<Task<ActionResult<List<Product>>>>(result);
            var actionResult = Assert.IsType<ActionResult<List<Product>>>(result.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var productList = Assert.IsType<List<Product>>(objectResult.Value);
            Assert.Equal(2, productList.Count);

        }

        [Fact]
        public void Index_ActionExecutes_ReturningCorrectObject() //ofärdig
        {
            _mockRepo.Setup(repo => repo.GetProductById(1))
                .ReturnsAsync(new Product() { Id = 1, Title = "Pippi", NumberOfCopiesOwned = 2, Published = DateTime.Now, Type = ProductType.Film, Creators = new(), Category = new() });
            var result = _controller.GetProductById(1);
            var viewResult = Assert.IsType<Task<ActionResult<Product>>>(result);
            var actionResult = Assert.IsType<ActionResult<Product>>(viewResult.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var taskProduct = Assert.IsType<Task<Product>>(objectResult.Value);
            var product = Assert.IsType<Product>(taskProduct.Result);

            Assert.Equal(1, product.Id);
            Assert.Equal("Pippi", product.Title);
            Assert.Equal(2, product.NumberOfCopiesOwned);
        }






    }
}
