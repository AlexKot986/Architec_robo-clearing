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
        public ActionResult<int> Add([FromBody] RobotAddRequest robotAddRequest)
        {
            return Ok(_robotRepository.Add(new Robot
            {
                StatusId = 1,
                Model = robotAddRequest.Model,
                Name = robotAddRequest.Name
            }));
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "RobotGetAll")]
        public ActionResult<IEnumerable<RobotResponce>> GetAll()
        {
            var robots = _robotRepository.GetAll();
            return Ok(robots.Select(r => new RobotResponce
            {
                Id = r.Id,
                StatusId = r.StatusId,
                Model = r.Model,
                Name = r.Name
            }));
        }

        [HttpGet("get/robot{id}")]
        [SwaggerOperation(OperationId = "RobotGetById")]
        public ActionResult<RobotResponce> GetById(int id)
        {
            try
            {
                var robot = _robotRepository.GetById(id);
                return Ok(new RobotResponce 
                { 
                    Id = robot.Id, 
                    StatusId = robot.StatusId,
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
        public ActionResult<int> Delete(int id)
        {
            try
            {
                return Ok(_robotRepository.Delete(id));
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "RobotUpdate")]
        public ActionResult<int> UpDate([FromBody] RobotUpdateRequest robotUpdateRequest)
        {
            try
            {
                return Ok(_robotRepository.UpDate(new Robot
                {
                    Id = robotUpdateRequest.Id,
                    StatusId = robotUpdateRequest.StatusId,
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
