# Project 08 - Global Exception Handling

## Objective

This project introduces global exception handling in ASP.NET Core.

Instead of writing repeated `try/catch` blocks in every Controller action, this project uses a custom middleware to catch exceptions in one centralized place.

## Learning Goals

- Why global exception handling is needed
- How exception middleware works
- How middleware catches exceptions from Controllers and Services
- How to define custom application exceptions
- How to map exceptions to HTTP status codes
- How to return consistent JSON error responses
- How to log application exceptions and unexpected exceptions differently

## Project Structure

```text
08-global-exception-handling/
├── 08-global-exception-handling.csproj
├── appsettings.json
├── Program.cs
├── Contracts/
│   ├── CreateUserRequest.cs
│   └── ErrorResponse.cs
├── Controllers/
│   └── UsersController.cs
├── Exceptions/
│   ├── AppException.cs
│   ├── DuplicateUserException.cs
│   ├── InvalidUserException.cs
│   └── UserNotFoundException.cs
├── Middleware/
│   ├── GlobalExceptionHandlingMiddleware.cs
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

## Core Flow

```text
Request
    ↓
GlobalExceptionHandlingMiddleware
    ↓
Controller
    ↓
Service
    ↓
Exception thrown
    ↑
Middleware catches it
    ↓
JSON error response
```

## Exception Mapping

| Exception | Status |
|---|---|
| InvalidUserException | 400 |
| UserNotFoundException | 404 |
| DuplicateUserException | 409 |
| Exception | 500 |

## Error Response Shape

```json
{
  "errorCode": "USER_NOT_FOUND",
  "message": "User with id 999 was not found.",
  "statusCode": 404,
  "traceId": "...",
  "path": "/api/users/999"
}
```

## Running

```bash
dotnet restore
dotnet run
```

Then test requests from `test.http`.

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| Exception Middleware | @ControllerAdvice |
| Custom Exception | Custom RuntimeException |
| ErrorResponse | Error DTO |
| LogError(ex, ...) | log.error(..., ex) |
| status code mapping | @ExceptionHandler |
