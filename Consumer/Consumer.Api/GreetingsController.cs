using Microsoft.AspNetCore.Mvc;

namespace Consumer.Api;

[ApiController]
[Route("/")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}
