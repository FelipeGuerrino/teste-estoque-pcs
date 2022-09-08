using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello world");
        }
    }
}