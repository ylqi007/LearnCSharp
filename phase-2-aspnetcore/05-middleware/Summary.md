# Project 05 Summary - Middleware

## Core Idea

Middleware is a component that processes HTTP requests and responses in the ASP.NET Core request pipeline.

A request does not go directly to a Controller. It flows through middleware first.

## Basic Request Flow

Before learning middleware:

```text
HTTP Request
    ↓
Controller
    ↓
Service
    ↓
HTTP Response
```

Real ASP.NET Core flow:

```text
HTTP Request
    ↓
Middleware A
    ↓
Middleware B
    ↓
Controller
    ↓
Middleware B
    ↓
Middleware A
    ↓
HTTP Response
```

Middleware can run code before and after the next component.

## Project Mental Model

```text
Request
    ↓
RequestLoggingMiddleware
    ↓
UsersController
    ↓
UserService
    ↓
Response
    ↑
RequestLoggingMiddleware
```

The same middleware sees both the request and the response.

## Program.cs

```csharp
app.UseRequestLogging();
app.MapGet("/", () => "Hello Middleware");
app.MapControllers();
```

`UseRequestLogging()` adds custom middleware to the request pipeline. `MapControllers()` maps Controller endpoints. Order matters.

## RequestLoggingMiddleware

```csharp
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public async Task InvokeAsync(HttpContext context)
    {
        // Before next middleware / endpoint
        await _next(context);
        // After next middleware / endpoint
    }
}
```

## RequestDelegate

`RequestDelegate` represents the next component in the pipeline.

```csharp
await _next(context);
```

This passes the request to the next middleware or endpoint.

If `_next(context)` is not called, the pipeline stops. This is called short-circuiting.

## HttpContext

`HttpContext` represents the current HTTP request and response.

Important properties:

```csharp
context.Request.Method
context.Request.Path
context.Response.StatusCode
context.User
context.Items
context.RequestServices
```

## Code Before and After _next

```csharp
_logger.LogInformation("Incoming request");
await _next(context);
_logger.LogInformation("Completed request");
```

Execution:

```text
Before _next
    ↓
Controller executes
    ↓
After _next
```

This is useful for logging, authentication, authorization, exception handling, response modification, and request correlation.

## Stopwatch

`Stopwatch.StartNew()` measures request duration. `stopwatch.ElapsedMilliseconds` shows how long the request took.

## ILogger

`ILogger<RequestLoggingMiddleware>` is injected by ASP.NET Core through DI. This project uses it to log request information. Project 06 will explain logging in more depth.

## Middleware Extension Method

```csharp
public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
{
    return app.UseMiddleware<RequestLoggingMiddleware>();
}
```

This allows cleaner registration:

```csharp
app.UseRequestLogging();
```

## Middleware Order

Middleware order is critical.

```csharp
app.UseMiddleware<A>();
app.UseMiddleware<B>();
```

Request order:

```text
A -> B -> Endpoint
```

Response order:

```text
Endpoint -> B -> A
```

The first middleware on the request is the last middleware on the response.

## Short-Circuiting

A middleware can stop the pipeline by not calling `_next(context)`.

```csharp
if (!authorized)
{
    context.Response.StatusCode = 401;
    return;
}
```

The Controller will never execute.

## Use vs Map vs Run

| Method | Meaning |
|---|---|
| `Use` | Add middleware to the pipeline |
| `Map` | Branch the pipeline by path |
| `Run` | Terminal middleware |
| `MapControllers` | Map Controller endpoints |
| `UseMiddleware<T>` | Add custom middleware class |

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| Middleware | Filter |
| Request Pipeline | Filter Chain |
| HttpContext | HttpServletRequest / HttpServletResponse |
| RequestDelegate | FilterChain |
| `await _next(context)` | `chain.doFilter(request, response)` |

## Common Interview Questions

### What is Middleware?

Middleware is a component in the ASP.NET Core request pipeline that can process requests and responses.

### What is the request pipeline?

The ordered chain of middleware components that an HTTP request flows through.

### What is HttpContext?

An object representing the current HTTP request and response.

### What is RequestDelegate?

A delegate representing the next component in the middleware pipeline.

### What does `await _next(context)` do?

It passes control to the next middleware or endpoint.

### Why does middleware order matter?

Requests flow in registration order, but responses flow back in reverse order.

### What happens if middleware does not call `_next`?

The pipeline stops and later middleware or Controllers do not run.

## Key Takeaways

1. Middleware is central to ASP.NET Core.
2. Requests pass through middleware before reaching Controllers.
3. Middleware can run logic before and after the Controller.
4. `HttpContext` contains request and response data.
5. `RequestDelegate` represents the next pipeline step.
6. `await _next(context)` continues the pipeline.
7. Middleware order is very important.
8. Extension methods provide clean middleware registration.
