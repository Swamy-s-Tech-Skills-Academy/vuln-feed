using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VulnFeed.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from VulnFeed.Web API!" });
    }
}
