using DockerVolumesPersistency.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DockerVolumesPersistency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;

        public CounterController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpPost("increment")]
        public async Task<IActionResult> IncrementAsync()
        {
            var result = await _counterService.IncrementAsync("executions");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _counterService.GetAsync("executions");

            return Ok(result);
        }
    }
}