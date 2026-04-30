using Net_metrics.DTO;

namespace Net_metrics.Services
{
    public interface IMetricsService
    {
        Task ProcessAsync(MetricDto dto);
    }
}
