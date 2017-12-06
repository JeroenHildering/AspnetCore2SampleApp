using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Api.Controllers
{
    [Route("api/[controller]"), Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
