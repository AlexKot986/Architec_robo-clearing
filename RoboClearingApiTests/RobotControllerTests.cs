using Microsoft.AspNetCore.Mvc;
using Moq;
using RoboClearingApi.Controllers;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Models.Responses;
using RoboClearingApi.Services;

namespace RoboClearingApiTests;

public class RobotControllerTests
{
    private RobotController _robotController = null;
    private Mock<IRobotRepository> _mockRobotRepository = null;
    private List<Robot> _list = null;
    
    [SetUp]
    public void Setup()
    {
        var _list = new List<Robot>{ new Robot(), new Robot() };
        _mockRobotRepository = new Mock<IRobotRepository>();
        _robotController = new RobotController(_mockRobotRepository.Object);
    }

    [Test]
    public async Task GetAllTest()
    {
        var _list = new List<Robot>{ new Robot(), new Robot() };
        _mockRobotRepository.Setup(repository => repository.GetAll()).ReturnsAsync(_list);

        var robotsActionResult = await _robotController.GetAll();

        Assert.IsNotNull(robotsActionResult);
        Assert.Equals(typeof(robots), nameof(IEnumerable<RobotResponce>));
        //Assert..IsType<OkObjectResult>(robotsActionResult.Result);
        //Assert.IsAssignableFrom<IEnumerable<RobotResponce>>(((OkObjectResult)robotsActionResult.Result).Value);
        _mockRobotRepository.Verify(repository => repository.GetAll(), Times.AtLeastOnce);
    }
       // Assert.Pass();
    
}