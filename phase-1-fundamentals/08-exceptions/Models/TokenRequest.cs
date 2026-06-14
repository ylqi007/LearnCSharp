namespace Exceptions.Models;

public class TokenRequest
{
    public required string ClientId { get; init; }
    public string? ClientSecret { get; init; }
    public string? Scope { get; init; }
}
