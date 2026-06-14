using AsyncAwait.Models;

namespace AsyncAwait.Services;

public class ExternalApiService
{
    public async Task<string> CallApiAsync(string endpoint)
    {
        await Task.Delay(600);
        return $"Response from {endpoint}";
    }

    public async Task<string> CallSlowApiAsync(string endpoint)
    {
        await Task.Delay(1500);
        return $"Slow response from {endpoint}";
    }

    public async Task<string> CallFailingApiAsync()
    {
        await Task.Delay(300);
        throw new InvalidOperationException("External API call failed.");
    }

    public async Task<ApiResult> CallApiWithTokenAsync(TokenResponse token, AppConfig config)
    {
        await Task.Delay(500);
        return new ApiResult
        {
            Message = $"Called {config.ApiEndpoint} with {token.AccessToken}"
        };
    }
}
