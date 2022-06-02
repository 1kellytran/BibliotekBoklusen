using BibliotekBoklusen.Server.Services.SeminarService;
using BibliotekBoklusen.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BibliotekBoklusen.Test.Controller
{
    public class SeminarServiceTests
    {
        private readonly Mock<ISeminarService> _mockRepo;
        private readonly SeminarsController _controller;

        public SeminarServiceTests()
        {
            _mockRepo = new Mock<ISeminarService>();
            _controller = new SeminarsController(_mockRepo.Object);
        }

        [Fact]
        public void GetAllSeminars_ActionExecutes_ShouldReturnTaskForGetAllSeminars()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetAllSeminars()).ReturnsAsync(new List<Seminarium> { new Seminarium(), new Seminarium() });

            var result = _controller.GetAllSeminars();
            var viewResult = Assert.IsType<Task<ActionResult<List<Seminarium>>>>(result);
            var actionResult = Assert.IsType<ActionResult<List<Seminarium>>>(result.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var seminarList = Assert.IsType<Task<List<Seminarium>>>(objectResult.Value);
            var seminarList2 = Assert.IsType<List<Seminarium>>(seminarList.Result);

            // Assert
            Assert.Equal(2, seminarList2.Count);
        }

        [Fact]
        public void GetSeminarById_ActionExecutes_ShouldReturnTaskForGetSeminarById()
        {

        }
    }
}
