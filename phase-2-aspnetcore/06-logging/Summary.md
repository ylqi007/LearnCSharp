# Project 06 Summary - Logging

## Core Idea

Logging is how backend services explain their runtime behavior.

A good service should produce logs that answer:

```text
What happened?
Where did it happen?
Why did it happen?
How long did it take?
Which request caused it?
```

## ILogger<T>

ASP.NET Core provides logging through DI.

```csharp
private readonly ILogger<UserService> _logger;

public UserService(ILogger<UserService> logger)
{
    _logger = logger;
}
```

`T` is the log category.

## Log Levels

| Level | Use Case |
|---|---|
| Trace | Extremely detailed diagnostics |
| Debug | Developer debugging information |
| Information | Normal application flow |
| Warning | Unexpected but recoverable situation |
| Error | Operation failed |
| Critical | Serious system failure |

## appsettings.json Logging Config

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "LoggingDemo": "Debug"
    }
  }
}
```

This controls which logs are displayed.

## Structured Logging

Good:

```csharp
_logger.LogInformation(
    "User was found. UserId = {UserId}, Email = {Email}",
    user.Id,
    user.Email);
```

Bad:

```csharp
_logger.LogInformation(
    $"User was found. UserId = {user.Id}, Email = {user.Email}");
```

Structured logging keeps values as searchable fields.

## Controller Logging

Controllers log API-level events:

- endpoint called
- important request parameters
- response decisions such as 404

## Service Logging

Services log business-level events:

- lookup results
- business decisions
- warnings
- failures

## Middleware Logging

Middleware logs request-level events:

- request start
- request completion
- status code
- elapsed time
- correlation id

## Correlation ID

A Correlation ID connects logs from the same request.

This project uses:

```text
X-Correlation-Id
```

## BeginScope

```csharp
using IDisposable? scope = _logger.BeginScope(
    new Dictionary<string, object>
    {
        ["CorrelationId"] = correlationId
    });
```

A logging scope attaches contextual data to logs within that scope.

## Request Flow

```text
HTTP Request
    ↓
RequestLoggingMiddleware
        - create/read CorrelationId
        - log request started
    ↓
UsersController
        - log endpoint-level information
    ↓
UserService
        - log business-level information
    ↓
RequestLoggingMiddleware
        - log status code and elapsed time
    ↓
HTTP Response
```

## What Not To Log

Avoid logging:

- passwords
- access tokens
- refresh tokens
- authorization headers
- secrets
- sensitive personal data
- full request bodies by default

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `ILogger<T>` | SLF4J Logger |
| `LogInformation` | `log.info` |
| `LogWarning` | `log.warn` |
| `LogError` | `log.error` |
| `BeginScope` | MDC |
| Correlation ID | Trace ID / Request ID |

## Key Takeaways

1. Logging is a production engineering skill.
2. ASP.NET Core injects `ILogger<T>` through DI.
3. Use the right log level.
4. Prefer structured logging.
5. Middleware is ideal for request-level logs.
6. Controllers log API-level decisions.
7. Services log business-level decisions.
8. Correlation IDs help trace one request across logs.
9. Never log secrets or tokens.
