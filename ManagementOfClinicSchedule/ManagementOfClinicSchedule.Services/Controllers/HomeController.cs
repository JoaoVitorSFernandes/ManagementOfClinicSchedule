using Microsoft.AspNetCore.Mvc;

namespace ManagementOfClinicSchedule.Services.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> HealthCheck() => Ok();
    }
}
