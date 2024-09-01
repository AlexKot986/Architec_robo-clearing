using Microsoft.AspNetCore.Mvc;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Models.Requests;
using RoboClearingApi.Models.Responses;
using RoboClearingApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboClearingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost("add")]
        [SwaggerOperation(OperationId = "RoomAdd")]
        public async Task<ActionResult<int>> Add([FromBody] RoomAddRequest robotAddRequest)
        {
            return Ok(await _roomRepository.Add(new Room
            {
                Name = robotAddRequest.Name
            }));
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "RoomGetAll")]
        public async Task<ActionResult<IEnumerable<RoomResponce>>> GetAll()
        {
            var robots = await _roomRepository.GetAll();
            return Ok(robots.Select(r => new RoomResponce
            {
                Id = r.Id,
                Name = r.Name
            }));
        }
    }
}