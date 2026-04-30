using Microsoft.AspNetCore.Mvc;
using Net_metrics.DTO;
using Net_metrics.Services;

namespace Net_metrics.Controllers
{
    [ApiController]
    [Route("api/metrics")]
    public class MetricsController : ControllerBase
    {
        private readonly IMetricsService _metricsService;

        public MetricsController(IMetricsService service)
        {
            _metricsService = service;
        }

        [HttpPost("transferBase")]
        public async Task<IActionResult> Post([FromBody] MetricDto dto)
        {
            await _metricsService.ProcessAsync(dto);
            return Ok();
        }
    }
}
