using Net_metrics.DTO;
using Net_metrics.Repository;
using Serilog;

namespace Net_metrics.Services
{
    public class MetricsService : IMetricsService
    {
        public MetricsService()
        {
        }

        public async Task ProcessAsync(MetricDto dto)
        {
            var metric = new Metric
            {
                ClientId = dto.ClientId,
                EventType = dto.EventType,
                Timestamp = dto.Timestamp == default
                    ? DateTime.UtcNow
                    : dto.Timestamp
            };

            Log.Information("Metric {@Metric}", metric);
        }
    }
}
