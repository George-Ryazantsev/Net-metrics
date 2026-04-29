using Microsoft.AspNetCore.Mvc;

namespace Net_metrics.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("ping")]
        public IActionResult Ping()
        {
            _logger.LogInformation("Ping event received at {Time}", DateTime.UtcNow);
            return Ok();
        }
    }
}
