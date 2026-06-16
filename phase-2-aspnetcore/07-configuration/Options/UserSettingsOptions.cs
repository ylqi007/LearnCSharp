namespace ConfigurationDemo.Options;

public class UserSettingsOptions
{
    public const string SectionName = "UserSettings";

    public int DefaultPageSize { get; set; }

    public bool AllowUserCreation { get; set; }

    public string DefaultEmailDomain { get; set; } = string.Empty;
}
