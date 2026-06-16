# Project 06 - Logging

## Objective

This project introduces logging in ASP.NET Core.

The goal is to understand:

- `ILogger<T>`
- Log levels
- Structured logging
- Logging in Controllers
- Logging in Services
- Logging in Middleware
- Correlation IDs
- `appsettings.json` logging configuration

## Project Structure

```text
06-logging/
├── 06-logging.csproj
├── appsettings.json
├── Program.cs
├── Controllers/
│   └── UsersController.cs
├── Middleware/
│   ├── RequestLoggingMiddleware.cs
│   └── MiddlewareExtensions.cs
├── Models/
│   └── User.cs
├── Services/
│   ├── IUserService.cs
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

## Core Idea

Logging helps answer:

- Was this endpoint called?
- Which user id was requested?
- Why did the request fail?
- How long did the request take?
- Which logs belong to the same request?

## Logging Configuration

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

## ILogger<T>

ASP.NET Core injects loggers through DI:

```csharp
private readonly ILogger<UsersController> _logger;
```

`T` is the logging category.

## Log Levels

| Level | Meaning |
|---|---|
| Trace | Very detailed diagnostic logs |
| Debug | Debugging information |
| Information | Normal application flow |
| Warning | Unexpected but recoverable situation |
| Error | Operation failed |
| Critical | Serious application failure |

## Structured Logging

Prefer:

```csharp
_logger.LogInformation(
    "User was found. UserId = {UserId}, Email = {Email}",
    user.Id,
    user.Email);
```

Avoid:

```csharp
_logger.LogInformation($"User was found. UserId = {user.Id}");
```

Structured logging keeps values as named fields.

## Correlation ID

This project uses `X-Correlation-Id`.

The middleware:

- reads it from the request if provided
- creates one if missing
- writes it to the response header
- includes it in logs

## Running

```bash
dotnet restore
dotnet run
```

Then send requests from `test.http`.

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `ILogger<T>` | SLF4J Logger |
| `LogInformation` | `log.info` |
| `LogWarning` | `log.warn` |
| `LogError` | `log.error` |
| `BeginScope` | MDC |
| Correlation ID | Trace ID / Request ID |


## 如何在 ASP.NET Core 中做生产级 logging
日志通常出现在三层

```
Middleware  ==> Middleware 记录 request-level log
    ↓
Controller  ==> Controller 记录 API-level log
    ↓
Service     ==> Service 记录 business-level log
```


## Appendix
* ASP.NET Core 内置 logging system 会自动提供 `ILogger<T>`。
* 
