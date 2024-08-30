using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoboClearingApi.Models.Requests;
using RoboClearingApi.Services;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Models.Responses;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RoboClearingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoboStatusController : ControllerBase
    {
        private readonly IRoboStatusRepository _roboStatusRepository;

        public RoboStatusController(IRoboStatusRepository roboStatusRepository)
        {
            _roboStatusRepository = roboStatusRepository;
        }

        [HttpPost("add")]
        [SwaggerOperation(OperationId = "RobostatusAdd")]
        public ActionResult<int> Add([FromBody] RoboStatusRequest roboStatusRequest)
        {
            try
            {
                return Ok(_roboStatusRepository.Add(new RoboStatus
                {
                    Title = roboStatusRequest.Title
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "RobostatusGetAll")]
        public ActionResult<IEnumerable<RoboStatusResponce>> GetAll()
        {         
            var roboStatuses = _roboStatusRepository.GetAll();  
            return Ok(roboStatuses.Select(rs => new RoboStatusResponce
            {
                Id = rs.Id,
                Title = rs.Title,
            }));
        }

        [HttpGet("get/robostatus{id}")]
        [SwaggerOperation(OperationId = "RobostatusGetById")]
        public ActionResult<RoboStatusResponce> GetById(int id)
        {
            try
            {
                var roboStatus = _roboStatusRepository.GetById(id);
                return Ok(new RoboStatusResponce { Id = roboStatus.Id, Title = roboStatus.Title });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
