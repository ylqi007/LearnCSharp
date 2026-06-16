# Project 05 - Middleware

## Objective

This project introduces Middleware in ASP.NET Core.

In previous projects, the mental model was:

```text
HTTP Request
    ↓
Controller
    ↓
Service
    ↓
HTTP Response
```

In real ASP.NET Core applications, requests pass through a pipeline before they reach Controllers:

```text
HTTP Request
    ↓
Middleware
    ↓
Middleware
    ↓
Controller
    ↓
Middleware
    ↓
Middleware
    ↓
HTTP Response
```

The goal is to understand the ASP.NET Core request pipeline and how to create custom middleware.

## Learning Goals

- Understand what Middleware is
- Understand the ASP.NET Core request pipeline
- Understand `HttpContext`
- Understand `RequestDelegate`
- Understand `await _next(context)`
- Understand why middleware order matters
- Create custom middleware
- Register middleware with `UseMiddleware<T>()`
- Create middleware extension methods

## Project Structure

```text
05-middleware/
├── 05-middleware.csproj
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

## Architecture

```text
HTTP Request
    ↓
RequestLoggingMiddleware
    ↓
Routing / Endpoint Selection
    ↓
UsersController
    ↓
UserService
    ↓
HTTP Response
    ↑
RequestLoggingMiddleware
```

The middleware runs both before and after the Controller.

## Program.cs

```csharp
app.UseRequestLogging();
app.MapControllers();
```

The order matters. `UseRequestLogging()` runs before requests reach Controllers.

## RequestLoggingMiddleware

The middleware logs:

- HTTP method
- Request path
- Response status code
- Elapsed time

Example output:

```text
Incoming request: GET /api/users
Completed request: GET /api/users responded 200 in 12 ms
```

## Key Code

```csharp
await _next(context);
```

This passes control to the next middleware in the pipeline. Code before `_next` runs before the Controller. Code after `_next` runs after the Controller.

## HttpContext

`HttpContext` represents the current HTTP request and response.

It contains:

- `context.Request`
- `context.Response`
- `context.User`
- `context.Items`
- `context.RequestServices`

## RequestDelegate

`RequestDelegate` represents the next component in the pipeline.

```csharp
private readonly RequestDelegate _next;
```

Calling:

```csharp
await _next(context);
```

means continue to the next middleware.

## Middleware Extension Method

Instead of writing:

```csharp
app.UseMiddleware<RequestLoggingMiddleware>();
```

this project defines:

```csharp
app.UseRequestLogging();
```

using an extension method.

## Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/` | Root greeting |
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get one user |
| POST | `/api/users` | Create user |

## Running

```bash
dotnet restore
dotnet run
```

Then send requests from `test.http`. Watch the terminal output to see middleware logs.

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| Middleware | Filter |
| HttpContext | HttpServletRequest / HttpServletResponse |
| RequestDelegate | FilterChain |
| `await _next(context)` | `chain.doFilter(request, response)` |
| Request Pipeline | Filter Chain |


## 总结

Middleware 就是包在 Controller 外面的一层 request/response 处理逻辑。

代码中体现为：

1. RequestLoggingMiddleware.cs 定义逻辑
2. MiddlewareExtensions.cs 提供 app.UseRequestLogging()
3. Program.cs 调用 app.UseRequestLogging()
4. await _next(context) 决定请求是否继续进入 Controller


## What Comes Next

Project 06 will introduce Logging in more detail.
