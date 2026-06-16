namespace ConfigurationDemo.Options;

public class ApplicationOptions
{
    public const string SectionName = "Application";

    public string Name { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string EnvironmentLabel { get; set; } = string.Empty;
}
