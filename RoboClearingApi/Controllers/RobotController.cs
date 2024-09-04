using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Models.Requests;
using RoboClearingApi.Models.Responses;
using RoboClearingApi.Services;
using RoboClearingApi.Services.Impl;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboClearingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IRobotRepository _robotRepository;

        public RobotController(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }

        [HttpPost("add")]
        [SwaggerOperation(OperationId = "RobotAdd")]
        public async Task<ActionResult<int>> Add([FromBody] RobotAddRequest robotAddRequest)
        {
            return Ok(await _robotRepository.Add(new Robot
            {
                Status = RoboStatus.Connecting,
                Model = robotAddRequest.Model,
                Name = robotAddRequest.Name
            }));
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "RobotGetAll")]
        public async Task<ActionResult<IEnumerable<RobotResponce>>> GetAll()
        {
            var robots = await _robotRepository.GetAll();
            return Ok(robots.Select(r => new RobotResponce
            {
                Id = r.Id,
                Status = r.Status,
                Model = r.Model,
                Name = r.Name
            }));
        }

        [HttpGet("get/robot{id}")]
        [SwaggerOperation(OperationId = "RobotGetById")]
        public async Task<ActionResult<RobotResponce>> GetById(int id)
        {
            try
            {
                var robot = await _robotRepository.GetById(id);
                return Ok(new RobotResponce 
                { 
                    Id = robot.Id, 
                    Status = robot.Status,
                    Model = robot.Model,
                    Name = robot.Name
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "RobotDelete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                return Ok(await _robotRepository.Delete(id));
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "RobotUpdate")]
        public async Task<ActionResult<int>> UpDate([FromBody] RobotUpdateRequest robotUpdateRequest)
        {
            try
            {
                return Ok(await _robotRepository.UpDate(new Robot
                {
                    Id = robotUpdateRequest.Id,
                    Status = robotUpdateRequest.Status,
                    Name = robotUpdateRequest.Name
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
