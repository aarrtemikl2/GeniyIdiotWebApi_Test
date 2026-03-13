using Microsoft.AspNetCore.Mvc;

namespace GeniyIdiotWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "HealthStatus")]
        public string Get()
        {
            return "API works";
        }
    }
}
