namespace AsyncAwait.Models;

public class ApiResult
{
    public required string Message { get; init; }

    public override string ToString() => $"ApiResult(Message = {Message})";
}
