using Microsoft.AspNetCore.Http;
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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        [HttpPost("add")]
        [SwaggerOperation(OperationId = "ScheduleAdd")]
        public async Task<ActionResult<int>> Add([FromBody] ScheduleAddRequest scheduleAddRequest)
        {
            return Ok(await _scheduleRepository.Add(new Schedule
            {
                RoomId = scheduleAddRequest.RoomId,
                RobotId = scheduleAddRequest.RobotId,
                Type = scheduleAddRequest.Type,
                WeekDays = scheduleAddRequest.WeekDays,
                Start = scheduleAddRequest.Start,
                End = scheduleAddRequest.End
            }));
        }

        [HttpGet("get-all")]
        [SwaggerOperation(OperationId = "ScheduleGetAll")]
        public async Task<ActionResult<IEnumerable<ScheduleResponce>>> GetAll()
        {
            var schedules = await _scheduleRepository.GetAll();
            return Ok(schedules.Select(s => new ScheduleResponce
            {
                Id = s.Id,
                RoomId = s.RoomId,
                RobotId = s.RobotId,
                Type = s.Type,
                WeekDays = s.WeekDays,
                Start = s.Start,
                End = s.End
            }));
        }

        [HttpGet("get/schedule{id}")]
        [SwaggerOperation(OperationId = "ScheduleGetById")]
        public async Task<ActionResult<ScheduleResponce>> GetById(int id)
        {
            try
            {
                var schedule = await _scheduleRepository.GetById(id);
                return Ok(new ScheduleResponce
                {
                    Id = schedule.Id,
                    RoomId = schedule.RoomId,
                    RobotId = schedule.RobotId,
                    Type = schedule.Type,
                    WeekDays = schedule.WeekDays,
                    Start = schedule.Start,
                    End = schedule.End
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        [SwaggerOperation(OperationId = "ScheduleDelete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                return Ok(await _scheduleRepository.Delete(id));
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        [SwaggerOperation(OperationId = "ScheduleUpdate")]
        public async Task<ActionResult<int>> UpDate([FromBody] ScheduleUpdateRequest scheduleUpdateRequest)
        {
            try
            {
                return Ok(await _scheduleRepository.UpDate(new Schedule
                {
                    Id = scheduleUpdateRequest.Id,
                    RoomId = scheduleUpdateRequest.RoomId,
                    RobotId = scheduleUpdateRequest.RobotId,
                    Type = scheduleUpdateRequest.Type,
                    WeekDays = scheduleUpdateRequest.WeekDays,
                    Start = scheduleUpdateRequest.Start,
                    End = scheduleUpdateRequest.End
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
