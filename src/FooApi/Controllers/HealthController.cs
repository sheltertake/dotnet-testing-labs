using Microsoft.AspNetCore.Mvc;

namespace FooApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            return new EmptyResult();
        }
    }
}
