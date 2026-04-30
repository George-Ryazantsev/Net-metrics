using Net_metrics.DTO;
using Net_metrics.Repository;
using System.Text.Json;

namespace Net_metrics.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly ILogger _logger;

        public MetricsService(ILogger<MetricsService> logger)
        {
            _logger = logger;
        }

        public async Task ProcessAsync(MetricDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ClientId))
                throw new ArgumentException("ClientId is required");

            var metric = new Metric
            {
                ClientId = dto.ClientId,
                EventType = dto.EventType,
                Timestamp = dto.Timestamp == default
                    ? DateTime.UtcNow
                    : dto.Timestamp
            };

            var json = JsonSerializer.Serialize(metric);
            _logger.LogInformation(json);
        }
    }
}
