namespace HealthChecksDemo.Services;

public class DemoDependencyOptions
{
    public const string SectionName = "DemoDependencies";

    public bool DatabaseAvailable { get; set; }

    public bool ExternalApiAvailable { get; set; }
}
