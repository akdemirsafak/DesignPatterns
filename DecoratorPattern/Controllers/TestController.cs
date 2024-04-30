using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Decorator Pattern");
        }
    }
}
