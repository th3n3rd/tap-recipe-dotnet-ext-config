using Microsoft.AspNetCore.Mvc;

namespace Provider.Api;

[ApiController]
[Route("/")]
public class Base64EncodingController : ControllerBase
{
    [HttpPost]
    public IActionResult Encode([FromBody] EncodeRequest request)
    {
        var encodedValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(request.Value));
        return Ok(encodedValue);
    }
    
    public class EncodeRequest
    {
        public string Value { get; set; }
    }
}
