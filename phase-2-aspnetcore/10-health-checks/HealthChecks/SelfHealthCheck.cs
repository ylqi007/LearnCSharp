using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksDemo.HealthChecks;

public class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            HealthCheckResult.Healthy(
                "The application process is running."));
    }
}
