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
        public void GetAllSeminars_ActionExecutes_ReturnNumbersOfSeminars()
        {
            _mockRepo.Setup(x => x.GetAllSeminars()).ReturnsAsync(new List<Seminarium> { new Seminarium(), new Seminarium() });

            var result = _controller.GetAllSeminars();
            var viewResult = Assert.IsType<Task<ActionResult<List<Seminarium>>>>(result);
            var actionResult = Assert.IsType<ActionResult<List<Seminarium>>>(result.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var seminarList = Assert.IsType<List<Seminarium>>(objectResult.Value);

            Assert.Equal(2, seminarList.Count);
        }

        [Fact]
        public void GetSeminarById_ActionExecutes_CorrectValuesForGetSeminarById()
        {
            _mockRepo.Setup(repo => repo.GetSeminarById(1))
                .ReturnsAsync(new Seminarium()
                {
                    Id = 1,
                    Title = "Kelly dansar",
                    SeminarDate = DateTime.Now,
                    SeminarTime = DateTime.Now,
                    FirstName = "Kelly",
                    LastName = "Tran"
                });

            var result = _controller.GetSeminarById(1);
            var viewResult = Assert.IsType<Task<ActionResult<Seminarium>>>(result);
            var actionResult = Assert.IsType<ActionResult<Seminarium>>(viewResult.Result);
            var objectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var taskSeminarium = Assert.IsType<Task<Seminarium>>(objectResult.Value);
            var seminarium = Assert.IsType<Seminarium>(taskSeminarium.Result);

            Assert.Equal(1, seminarium.Id);
            Assert.Equal("Kelly dansar", seminarium.Title);
            Assert.Equal("Kelly", seminarium.FirstName);

        }

        [Fact]
        public void Create_ActionExecutes_GetCorrectResponse()
        {
            var seminar = new Seminarium
            {
                Id = 1,
                Title = "Kelly dansar",
                SeminarDate = DateTime.Now,
                SeminarTime = DateTime.Now,
                FirstName = "Kelly",
                LastName = "Tran"
            };

            _mockRepo.Setup(repo => repo.CreateSeminar(seminar));
            var result = _controller.CreateSeminar(seminar);
            var taskResult = Assert.IsType<Task<ActionResult>>(result);
            var actionResult = Assert.IsType<OkObjectResult>(taskResult.Result);
        }

        [Fact]
        public void Delete_ActionExecutes_GetCorrectResponse()
        {
            var seminar = new Seminarium
            {
                Id = 1,
                Title = "Kelly dansar",
                SeminarDate = DateTime.Now,
                SeminarTime = DateTime.Now,
                FirstName = "Kellys",
                LastName = "Mamma"
            };

            var result = _controller.DeleteSeminar(seminar.Id);
            var taskResult = Assert.IsType<Task<ActionResult>>(result);
            Assert.IsType<OkObjectResult>(taskResult.Result);
        }

        [Fact]
        public async Task DeleteUserFromDb_VerifyDeleteUser()
        {
            var seminarId = 2;
            _mockRepo.Setup(u => u.DeleteSeminar(seminarId));

            await _mockRepo.Object.DeleteSeminar(seminarId);

            _mockRepo.Verify(u => u.DeleteSeminar(seminarId));
        }

        [Fact]
        public void Put_ActionExecutes_ReturnOkObjectResult()
        {
            var seminar = new Seminarium
            {
                Id = 1,
                Title = "Kelly dansar",
                SeminarDate = DateTime.Now,
                SeminarTime = DateTime.Now,
                FirstName = "Kelly",
                LastName = "Tran"
            };

            var taskResult = _controller.DeleteSeminar(seminar.Id);
            var result = Assert.IsType<Task<ActionResult>>(taskResult);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
