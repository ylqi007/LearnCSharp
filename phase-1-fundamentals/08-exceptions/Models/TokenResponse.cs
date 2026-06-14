namespace Exceptions.Models;

public class TokenResponse
{
    public required string AccessToken { get; init; }
    public DateTime ExpiresAt { get; init; }

    public override string ToString()
    {
        return $"TokenResponse(AccessToken = {AccessToken}, ExpiresAt = {ExpiresAt:u})";
    }
}
