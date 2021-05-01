using Microsoft.AspNetCore.Mvc;
using Entities;

namespace Api.Controllers
{
    ///HealthCheck
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        ///Check status
        [HttpGet]
        [HttpPost]
        public IActionResult CheckStatus()
        {
            return Ok("Working as expected");
        }
    }
}
