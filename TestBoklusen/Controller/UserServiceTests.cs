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
            var result = _controller.GetAllUser();

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

        [Fact]
        public void GetUser_ActionExecutes_ShouldReturnCorrectObject()
        {
            _mockRepo.Setup(repo => repo.GetUser(1))
                .ReturnsAsync(new User() { Id = 1, FirstName="Leif" });
            var result = _controller.GetUser(1);
            var viewResult = Assert.IsType<Task<ActionResult<User>>>(result);
            var actionResult = Assert.IsType<ActionResult<User>>(viewResult.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var taskUser = Assert.IsType<Task<User>>(objectResult.Value);
            var User = Assert.IsType<User>(taskUser.Result);

            Assert.Equal(1, User.Id);
            Assert.Equal("Leif", User.FirstName);

        }

        [Fact]
        public void GetCurrentUser_ShouldReturnUserById()
        {
            _mockRepo.Setup(repo => repo.GetCurrentUser("Test@hotmail.com"))
                .ReturnsAsync(new User() { Email = "Test@hotmail.com" });
            var result = _controller.GetCurrentUser("Test@hotmail.com");
            var viewResult = Assert.IsType<Task<ActionResult<User>>>(result);
            var actionResult = Assert.IsType<ActionResult<User>>(viewResult.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var User = Assert.IsType<User>(objectResult.Value);

            Assert.Equal("Test@hotmail.com", User.Email);

        }
        [Fact]
        public async Task DeleteUserFromDb_ShouldDeleteUser()
        {
           
            var userId = 2;
            _mockRepo.Setup(u => u.DeleteUserFromDb(userId));

            await _mockRepo.Object.DeleteUserFromDb(userId);

            _mockRepo.Verify(u => u.DeleteUserFromDb(userId));
<<<<<<< Updated upstream
=======
       
        }
>>>>>>> Stashed changes


        }
        [Fact]
        public async Task DeleteUserFromAuthDbContext_ShouldDeleteUser()
        {
            //Arrange
            var userEmail = "Test@hotmail.com";
            _mockRepo.Setup(u => u.DeleteUserFromAuthDbContext(userEmail));
            //Act
            await _mockRepo.Object.DeleteUserFromAuthDbContext(userEmail);

            //Assert
            _mockRepo.Verify(u => u.DeleteUserFromAuthDbContext(userEmail));


        }

        [Fact]
        public void ChangePassword_ShouldChangePassword()                                                                                                                                                                                                 
        {
            PasswordDto password = null;
            _mockRepo.Setup(r => r.ChangePassword(It.IsAny<PasswordDto>()))
          .Callback<PasswordDto>(x => password = x);

            var user = new PasswordDto
            {

             NewPassword = "Test123",
             OldPassword = "FinBoll12",
             NewPasswordConfirmed ="Test123"
             
             
            };
            _controller.ChangePassword(user);
            _mockRepo.Verify(x => x.ChangePassword(It.IsAny<PasswordDto>()), Times.Once);
            Assert.Equal(password.NewPassword, user.NewPassword);
            Assert.Equal(password.OldPassword, user.OldPassword);
            Assert.Equal(password.NewPasswordConfirmed, user.NewPasswordConfirmed);

        }

        //[Fact]
        //public void Create_ ModelStateValid_CreateEmployeeCalledOnce()
        //{
        //    Employee? emp = null;
        //    _mockRepo.Setup(r => r.CreateEmployee(It.IsAny<Employee>()))
        //        .Callback<Employee>(x => emp = x);
        //    var employee = new Employee
        //    {
        //        Name = "Test Employee",
        //        Age = 32,
        //        AccountNumber = "123-5435789603-21"
        //    };
        //    _controller.Create(employee);
        //    _mockRepo.Verify(x => x.CreateEmployee(It.IsAny<Employee>()), Times.Once);
        //    Assert.Equal(emp.Name, employee.Name);
        //    Assert.Equal(emp.Age, employee.Age);
        //    Assert.Equal(emp.AccountNumber, employee.AccountNumber);
        //}






    }


}

