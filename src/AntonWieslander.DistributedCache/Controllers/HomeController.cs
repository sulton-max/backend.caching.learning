using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace AntonWieslander.DistributedCache.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        public async Task<IActionResult> Home([FromServices]IDistributedCache cache)
        {
            return Ok(await cache.GetStringAsync("Bob"));
        }
    }
}
