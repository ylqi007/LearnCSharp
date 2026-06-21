namespace HealthChecksDemo.Services;

public interface IDemoDependencyStatus
{
    bool IsDatabaseAvailable();

    bool IsExternalApiAvailable();

    void SetDatabaseAvailability(bool isAvailable);

    void SetExternalApiAvailability(bool isAvailable);
}
