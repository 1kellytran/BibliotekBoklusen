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

        [Fact]
        public void GetUser_ActionExecutes_ShouldReturnCorrectObject()
        {
            _mockRepo.Setup(repo => repo.GetUser(1))
                .ReturnsAsync(new User() { Id = 1 });
            var result = _controller.GetUser(1);
            var viewResult = Assert.IsType<Task<ActionResult<User>>>(result);
            var actionResult = Assert.IsType<ActionResult<User>>(viewResult.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var taskUser = Assert.IsType<Task<User>>(objectResult.Value);
            var User = Assert.IsType<User>(taskUser.Result);

            Assert.Equal(1, User.Id);

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
            //Arrange
            var userId = 2;
            _mockRepo.Setup(u => u.DeleteUserFromDb(userId));
            //Act
            await _mockRepo.Object.DeleteUserFromDb(userId);

            //Assert
            _mockRepo.Verify(u => u.DeleteUserFromDb(userId));
       
        ////Act
        //await studentService.Object.RemoveStudent(studentId);
        ////Assert
        //studentService.Verify(repo => repo.RemoveStudent(studentId), Times.Once);
        }


        //[Fact]
        //public async Task UpdateUser_ShouldUpdateUser()
        //{
        //    //Arrange
        //    var updateUser = new UpdatedUserDto();
        //    updateUser.IsLibrarian = true;
        //    updateUser.FirstName = "Test";
        //    updateUser.LastName = "lol";
        //    _mockRepo.Setup(x => x.)




        //}

        //[Fact]
        //public async Task UpdateUser_ShouldUpdateUser()
        //{
        //        //Arrange
        //        UpdatedUserDto user = new();
        //        _mockRepo.Setup(repo => repo.UpdateUser(user, 1)).Returns(new User() { FirstName = "bla", LastName = "tia", IsLibrarian = true, Id=1 }  ); 

        //{
        //    updateUser.IsLibrarian = true;
        //    updateUser.FirstName = "Test";
        //    updateUser.LastName = "lol";
        //};
        ////Act
        //await _mockRepo.Object.UpdateStudent(studData);
        ////Assert
        //studentService.Verify(x => x.UpdateStudent(It.IsAny<StudentEntity>()), Times.Once);
        //Assert.Equal(studentEntity.FirstName, studData.FirstName);
        //Assert.Equal(studentEntity.LastName, studData.LastName);
        //Assert.Equal(studentEntity.DOB, studData.DOB);
        //Assert.Equal(studentEntity.Email, studData.Email);
    }

 

    //Task<ServiceResponse<string>> DeleteUserFromDb(int id);


}

