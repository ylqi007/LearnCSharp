namespace AsyncAwait.Models;

public class TokenResponse
{
    public required string AccessToken { get; init; }
    public DateTime ExpiresAt { get; init; }

    public override string ToString() => $"TokenResponse(AccessToken = {AccessToken}, ExpiresAt = {ExpiresAt:u})";
}
