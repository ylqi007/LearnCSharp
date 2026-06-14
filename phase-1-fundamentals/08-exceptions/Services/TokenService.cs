using Exceptions.Exceptions;
using Exceptions.Models;

namespace Exceptions.Services;

public class TokenService
{
    public TokenResponse IssueToken(TokenRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ClientId))
        {
            throw new InvalidTokenRequestException("ClientId is required.");
        }

        if (string.IsNullOrWhiteSpace(request.ClientSecret))
        {
            throw new InvalidTokenRequestException("ClientSecret is required.");
        }

        if (request.ClientSecret != "valid-secret")
        {
            throw new AuthenticationFailedException(
                request.ClientId,
                $"Authentication failed for client '{request.ClientId}'.");
        }

        return new TokenResponse
        {
            AccessToken = "sample-access-token",
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
    }

    public async Task<TokenResponse> IssueTokenAsync(TokenRequest request)
    {
        await Task.Delay(100);
        return IssueToken(request);
    }
}
