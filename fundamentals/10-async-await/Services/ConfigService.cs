using AsyncAwait.Models;

namespace AsyncAwait.Services;

public class ConfigService
{
    public async Task<AppConfig> GetConfigAsync()
    {
        await Task.Delay(400);

        return new AppConfig
        {
            Environment = "Development",
            ApiEndpoint = "https://api.example.com"
        };
    }
}
