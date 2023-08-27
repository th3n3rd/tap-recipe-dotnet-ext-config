using Microsoft.AspNetCore.Mvc;

namespace Consumer.Api;

[ApiController]
[Route("/")]
public class GreetingsController : ControllerBase
{
    private readonly EncodingApiClient _encodingApiClient;

    public GreetingsController(EncodingApiClient encodingApiClient)
    {
        _encodingApiClient = encodingApiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var original = "Hello World!";
        return Ok(new GreetingResponse
        {
            Original = original,
            Encoded = await _encodingApiClient.Encode(original)
        });
    }

    private class GreetingResponse
    {
        public string Original { get; set; }
        public string Encoded { get; set; }
    }
}
