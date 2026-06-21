using HealthChecksDemo.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksDemo.HealthChecks;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly IDemoDependencyStatus _dependencyStatus;
    private readonly ILogger<DatabaseHealthCheck> _logger;

    public DatabaseHealthCheck(
        IDemoDependencyStatus dependencyStatus,
        ILogger<DatabaseHealthCheck> logger)
    {
        _dependencyStatus = dependencyStatus;
        _logger = logger;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        bool databaseAvailable =
            _dependencyStatus.IsDatabaseAvailable();

        if (databaseAvailable)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy(
                    "Database dependency is available.",
                    new Dictionary<string, object>
                    {
                        ["dependency"] = "database"
                    }));
        }

        _logger.LogWarning(
            "Database health check failed.");

        return Task.FromResult(
            HealthCheckResult.Unhealthy(
                "Database dependency is not available.",
                data: new Dictionary<string, object>
                {
                    ["dependency"] = "database"
                }));
    }
}
