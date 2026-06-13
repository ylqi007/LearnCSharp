using AsyncAwait.Models;
using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class FanOutFanInExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Fan-Out / Fan-In Examples =====");

        var tokenService = new TokenService();
        var configService = new ConfigService();
        var apiService = new ExternalApiService();

        Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(
            new TokenRequest
            {
                ClientId = "managed-identity-client",
                Scope = "https://management.azure.com/.default"
            });

        Task<AppConfig> configTask = configService.GetConfigAsync();

        await Task.WhenAll(tokenTask, configTask);

        TokenResponse token = await tokenTask;
        AppConfig config = await configTask;

        ApiResult result = await apiService.CallApiWithTokenAsync(token, config);

        Console.WriteLine(token);
        Console.WriteLine(config);
        Console.WriteLine(result);
    }
}
