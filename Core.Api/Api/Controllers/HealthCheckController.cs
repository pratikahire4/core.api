using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [HttpPost]
        public IActionResult CheckStatus()
        {
            return Ok("Working as expected");
        }
    }
}
