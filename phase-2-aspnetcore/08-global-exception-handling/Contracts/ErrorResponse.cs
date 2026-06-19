namespace GlobalExceptionDemo.Contracts;

public class ErrorResponse
{
    public string ErrorCode { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public string TraceId { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}
