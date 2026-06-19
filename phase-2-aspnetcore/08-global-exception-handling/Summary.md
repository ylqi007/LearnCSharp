# Project 08 Summary - Global Exception Handling

## Core Idea

Global exception handling centralizes error handling for the whole ASP.NET Core application.

Instead of writing `try/catch` in every Controller, exceptions bubble up to middleware.

## Request Flow

```text
HTTP Request
    ↓
GlobalExceptionHandlingMiddleware
    ↓
Controller
    ↓
Service
    ↓
Exception thrown
    ↑
Middleware catches exception
    ↓
JSON Error Response
```

## GlobalExceptionHandlingMiddleware

```csharp
try
{
    await _next(context);
}
catch (AppException ex)
{
    await HandleAppExceptionAsync(context, ex);
}
catch (Exception ex)
{
    await HandleUnexpectedExceptionAsync(context, ex);
}
```

`await _next(context)` executes downstream middleware, endpoints, controllers, and services.

## AppException

`AppException` is the base class for expected application errors.

It contains:

- ErrorCode
- StatusCode
- Message

## Expected vs Unexpected Errors

Expected application errors:

- invalid input
- missing resource
- duplicate resource

Unexpected system errors:

- null reference
- database failure
- unknown runtime failure

## Mapping

| Exception | HTTP Status |
|---|---|
| InvalidUserException | 400 |
| UserNotFoundException | 404 |
| DuplicateUserException | 409 |
| Exception | 500 |

## Logging Strategy

Expected application exceptions use:

```csharp
_logger.LogWarning(exception, ...);
```

Unexpected exceptions use:

```csharp
_logger.LogError(exception, ...);
```

## Middleware Order

Exception middleware should be registered early:

```csharp
app.UseGlobalExceptionHandling();
app.MapControllers();
```

It must wrap downstream endpoints.

## Key Takeaways

1. Global exception handling avoids repeated try/catch blocks.
2. Middleware can catch exceptions from Controllers and Services.
3. Custom exceptions map business errors to HTTP status codes.
4. API clients get a consistent error contract.
5. Do not expose internal exception details in 500 responses.
6. Expected errors are usually warnings.
7. Unexpected failures are errors.
