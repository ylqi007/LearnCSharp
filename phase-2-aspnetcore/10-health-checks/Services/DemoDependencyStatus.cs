using Microsoft.Extensions.Options;

namespace HealthChecksDemo.Services;

public class DemoDependencyStatus : IDemoDependencyStatus
{
    private bool _databaseAvailable;
    private bool _externalApiAvailable;

    public DemoDependencyStatus(
        IOptions<DemoDependencyOptions> options)
    {
        _databaseAvailable = options.Value.DatabaseAvailable;
        _externalApiAvailable = options.Value.ExternalApiAvailable;
    }

    public bool IsDatabaseAvailable()
    {
        return _databaseAvailable;
    }

    public bool IsExternalApiAvailable()
    {
        return _externalApiAvailable;
    }

    public void SetDatabaseAvailability(bool isAvailable)
    {
        _databaseAvailable = isAvailable;
    }

    public void SetExternalApiAvailability(bool isAvailable)
    {
        _externalApiAvailable = isAvailable;
    }
}
