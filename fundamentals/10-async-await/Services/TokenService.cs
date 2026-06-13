using AsyncAwait.Models;

namespace AsyncAwait.Services;

public class TokenService
{
    public async Task<TokenResponse> GetTokenAsync(TokenRequest request)
    {
        await Task.Delay(500);

        if (string.IsNullOrWhiteSpace(request.ClientId))
        {
            throw new ArgumentException("ClientId is required.", nameof(request));
        }

        return new TokenResponse
        {
            AccessToken = $"token-for-{request.ClientId}-{request.Scope}",
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
    }

    public async Task<TokenResponse> GetTokenWithCancellationAsync(
        TokenRequest request,
        CancellationToken cancellationToken)
    {
        await Task.Delay(3000, cancellationToken);

        return new TokenResponse
        {
            AccessToken = $"cancelable-token-for-{request.ClientId}",
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
    }
}
