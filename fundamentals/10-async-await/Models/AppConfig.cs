namespace AsyncAwait.Models;

public class AppConfig
{
    public required string Environment { get; init; }
    public required string ApiEndpoint { get; init; }

    public override string ToString() => $"AppConfig(Environment = {Environment}, ApiEndpoint = {ApiEndpoint})";
}
