using HealthChecksDemo.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksDemo.HealthChecks;

public class ExternalApiHealthCheck : IHealthCheck
{
    private readonly IDemoDependencyStatus _dependencyStatus;
    private readonly ILogger<ExternalApiHealthCheck> _logger;

    public ExternalApiHealthCheck(
        IDemoDependencyStatus dependencyStatus,
        ILogger<ExternalApiHealthCheck> logger)
    {
        _dependencyStatus = dependencyStatus;
        _logger = logger;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        bool externalApiAvailable =
            _dependencyStatus.IsExternalApiAvailable();

        if (externalApiAvailable)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy(
                    "External API dependency is available.",
                    new Dictionary<string, object>
                    {
                        ["dependency"] = "external-api"
                    }));
        }

        _logger.LogWarning(
            "External API health check is degraded.");

        return Task.FromResult(
            HealthCheckResult.Degraded(
                "External API dependency is degraded.",
                data: new Dictionary<string, object>
                {
                    ["dependency"] = "external-api"
                }));
    }
}
