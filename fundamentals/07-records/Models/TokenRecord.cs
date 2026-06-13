namespace Records.Models;

public record TokenRecord
{
    public required string TokenType { get; init; }

    public required string AccessToken { get; init; }

    public DateTime ExpiresAt { get; init; }

    public bool IsExpired()
    {
        return DateTime.UtcNow >= ExpiresAt;
    }
}
