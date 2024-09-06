using Microsoft.AspNetCore.Mvc;
using Moq;
using RoboClearingApi.Controllers;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Models.Requests;
using RoboClearingApi.Models.Responses;
using RoboClearingApi.Services;

namespace RoboClearingTests;

public class RobotControllerTests
{
    private readonly RobotController _robotController;
    private readonly Mock<IRobotRepository> _mockRobotRepository;

    public RobotControllerTests()
    {
        _mockRobotRepository = new Mock<IRobotRepository>();
        _robotController = new RobotController(_mockRobotRepository.Object);
    }

    [Fact]
    public async void GetAllTest()
    {
        var list = new List<Robot>{ new Robot(), new Robot() };
        _mockRobotRepository.Setup(repository => repository.GetAll()).ReturnsAsync(list);

        var robotsActionResult = await _robotController.GetAll();

        Assert.IsType<OkObjectResult>(robotsActionResult.Result);
        Assert.IsAssignableFrom<IEnumerable<RobotResponce>>(((OkObjectResult)robotsActionResult.Result).Value);
        _mockRobotRepository.Verify(repository => repository.GetAll(), Times.AtLeastOnce);
    }

    [Fact]
    public async void AddRobotTest()
    {
        var robot = new RobotAddRequest();
        _mockRobotRepository.Setup(repository => repository.Add(It.IsNotNull<Robot>())).ReturnsAsync(1).Verifiable();

        var answerActionResult = await _robotController.Add(robot);

        Assert.IsType<OkObjectResult>(answerActionResult.Result);
        Assert.IsAssignableFrom<int>(((OkObjectResult)answerActionResult.Result).Value);
        _mockRobotRepository.Verify(repository => repository.Add(It.IsNotNull<Robot>()), Times.AtLeastOnce());
    }
}