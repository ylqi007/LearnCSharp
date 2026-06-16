using System.Diagnostics;

namespace MiddlewareDemo.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        string method = context.Request.Method;
        string path = context.Request.Path;

        _logger.LogInformation("Incoming request: {Method} {Path}", method, path);

        await _next(context);

        stopwatch.Stop();

        int statusCode = context.Response.StatusCode;

        _logger.LogInformation(
            "Completed request: {Method} {Path} responded {StatusCode} in {ElapsedMilliseconds} ms",
            method,
            path,
            statusCode,
            stopwatch.ElapsedMilliseconds);
    }
}
