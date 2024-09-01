using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoboClearingApi.Models.Domain;
using RoboClearingApi.Services.NotImpl;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboClearingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController(TypeOfClearingRepository _tupeRepository) : ControllerBase
    {
        [HttpPost("create")]
        [SwaggerOperation(OperationId = "TypesCreate")]
        public async Task<ActionResult<int>> Create()
        {
            try
            {
                return Ok(await _tupeRepository.CreateTypes());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
