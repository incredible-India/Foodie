using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Controllers
{
    [Route("")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        [HttpGet("")]
        public IActionResult signIn()
        {
            return Content("hello world");
        }
    }
}
