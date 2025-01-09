using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServerApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [Authorize]
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Test endpoint working!");
    }
}
