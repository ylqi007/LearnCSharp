namespace Generics.Models;

public class Token : IEntity
{
    public string Id { get; init; } = string.Empty;

    public string Value { get; init; } = string.Empty;

    public DateTime ExpiresAt { get; init; }

    public bool IsExpired()
    {
        return DateTime.UtcNow >= ExpiresAt;
    }

    public override string ToString()
    {
        return $"Token(Id = {Id}, ExpiresAt = {ExpiresAt:u})";
    }
}
