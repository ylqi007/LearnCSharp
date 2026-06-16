using System.Diagnostics;

namespace LoggingDemo.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string correlationId = GetOrCreateCorrelationId(context);
        context.Response.Headers["X-Correlation-Id"] = correlationId;

        using IDisposable? scope = _logger.BeginScope(
            new Dictionary<string, object>
            {
                ["CorrelationId"] = correlationId
            });

        Stopwatch stopwatch = Stopwatch.StartNew();

        _logger.LogInformation(
            "HTTP request started. Method = {Method}, Path = {Path}, CorrelationId = {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            correlationId);

        await _next(context);

        stopwatch.Stop();

        _logger.LogInformation(
            "HTTP request completed. Method = {Method}, Path = {Path}, StatusCode = {StatusCode}, ElapsedMs = {ElapsedMs}, CorrelationId = {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds,
            correlationId);
    }

    private static string GetOrCreateCorrelationId(HttpContext context)
    {
        const string headerName = "X-Correlation-Id";

        if (context.Request.Headers.TryGetValue(headerName, out var correlationId)
            && !string.IsNullOrWhiteSpace(correlationId))
        {
            return correlationId.ToString();
        }

        return Guid.NewGuid().ToString("N");
    }
}
