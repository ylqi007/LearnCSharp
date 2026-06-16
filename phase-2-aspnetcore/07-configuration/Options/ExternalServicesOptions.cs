namespace ConfigurationDemo.Options;

public class ExternalServicesOptions
{
    public const string SectionName = "ExternalServices";

    public string UserProfileServiceUrl { get; set; } = string.Empty;

    public int TimeoutSeconds { get; set; }

    public int RetryCount { get; set; }
}
