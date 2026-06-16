using ConfigurationDemo.Options;
using Microsoft.Extensions.Options;

namespace ConfigurationDemo.Services;

public class ConfigurationReporter : IConfigurationReporter
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;
    private readonly ApplicationOptions _applicationOptions;
    private readonly UserSettingsOptions _userSettingsOptions;
    private readonly ExternalServicesOptions _externalServicesOptions;

    public ConfigurationReporter(
        IConfiguration configuration,
        IWebHostEnvironment environment,
        IOptions<ApplicationOptions> applicationOptions,
        IOptions<UserSettingsOptions> userSettingsOptions,
        IOptions<ExternalServicesOptions> externalServicesOptions)
    {
        _configuration = configuration;
        _environment = environment;
        _applicationOptions = applicationOptions.Value;
        _userSettingsOptions = userSettingsOptions.Value;
        _externalServicesOptions = externalServicesOptions.Value;
    }

    public object GetReport()
    {
        return new
        {
            Environment = _environment.EnvironmentName,
            RawConfiguration = new
            {
                ApplicationName = _configuration["Application:Name"],
                ApplicationVersion = _configuration["Application:Version"],
                EnvironmentLabel = _configuration["Application:EnvironmentLabel"],
                DefaultPageSize = _configuration["UserSettings:DefaultPageSize"],
                DefaultEmailDomain = _configuration["UserSettings:DefaultEmailDomain"],
                UserProfileServiceUrl = _configuration["ExternalServices:UserProfileServiceUrl"]
            },
            StronglyTypedOptions = new
            {
                Application = _applicationOptions,
                UserSettings = _userSettingsOptions,
                ExternalServices = _externalServicesOptions
            }
        };
    }
}
