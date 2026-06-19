using System.Text.Json;
using GlobalExceptionDemo.Contracts;
using GlobalExceptionDemo.Exceptions;

namespace GlobalExceptionDemo.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            _logger.LogInformation("==> Middleware Begin: {Path}", context.Request.Path);
            await _next(context);
            _logger.LogInformation("====> Middleware End: {Path}", context.Request.Path);
        }
        catch (AppException ex)
        {
            await HandleAppExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleUnexpectedExceptionAsync(context, ex);
        }
    }

    private async Task HandleAppExceptionAsync(HttpContext context, AppException exception)
    {
        _logger.LogWarning(
            exception,
            "Application exception occurred. ErrorCode = {ErrorCode}, StatusCode = {StatusCode}, Path = {Path}",
            exception.ErrorCode,
            exception.StatusCode,
            context.Request.Path);

        ErrorResponse response = new()
        {
            ErrorCode = exception.ErrorCode,
            Message = exception.Message,
            StatusCode = exception.StatusCode,
            TraceId = context.TraceIdentifier,
            Path = context.Request.Path
        };

        await WriteJsonResponseAsync(context, exception.StatusCode, response);
    }

    private async Task HandleUnexpectedExceptionAsync(HttpContext context, Exception exception)
    {
        const int statusCode = StatusCodes.Status500InternalServerError;

        _logger.LogError(
            exception,
            "Unhandled exception occurred. Path = {Path}",
            context.Request.Path);

        ErrorResponse response = new()
        {
            ErrorCode = "INTERNAL_SERVER_ERROR",
            Message = "An unexpected error occurred.",
            StatusCode = statusCode,
            TraceId = context.TraceIdentifier,
            Path = context.Request.Path
        };

        await WriteJsonResponseAsync(context, statusCode, response);
    }

    private static async Task WriteJsonResponseAsync(
        HttpContext context,
        int statusCode,
        ErrorResponse response)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        string json = JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        await context.Response.WriteAsync(json);
    }
}
