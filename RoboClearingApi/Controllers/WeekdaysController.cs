using Microsoft.AspNetCore.Mvc;
using RoboClearingApi.Services.NotImpl;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboClearingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekdaysController(WeekDayRepository _weekDayRepository) : ControllerBase
    {
        [HttpPost("create")]
        [SwaggerOperation(OperationId = "WeekDaysCreate")]
        public async Task<ActionResult<int>> Create()
        {
            try
            {
                  return Ok(await _weekDayRepository.CreateDays());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}