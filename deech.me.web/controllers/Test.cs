using Microsoft.AspNetCore.Mvc;

namespace deech.me.web.controllers
{
    [Route("[controller]")]
    public class Test : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello");
        }
    }
}