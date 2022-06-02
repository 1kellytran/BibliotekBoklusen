using BibliotekBoklusen.Server.Services;
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
    public class UserServiceTests
    {
        private readonly Mock<IUserService> _mockRepo;
        private readonly UserController _controller;
        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserService>();
            _controller = new UserController(_mockRepo.Object);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            //Arrange
         
            //Act
            var result = _controller.GetAllUser();

            // Assert
            Assert.IsType<Task<ActionResult<List<User>>>>(result);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnsExactNumberOfÚsers()
        {
            _mockRepo.Setup(repo => repo.GetAllUser()).ReturnsAsync(new List<User> { new User(), new User() });

            var result = _controller.GetAllUser();
            var viewResult = Assert.IsType<Task<ActionResult<List<User>>>>(result);
            var actionResult = Assert.IsType<ActionResult<List<User>>>(result.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var productList = Assert.IsType<List<User>>(objectResult.Value);
            Assert.Equal(2, productList.Count);

        }



    }
}
