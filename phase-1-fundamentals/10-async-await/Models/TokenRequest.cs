namespace AsyncAwait.Models;

public class TokenRequest
{
    public required string ClientId { get; init; }
    public required string Scope { get; init; }
}
