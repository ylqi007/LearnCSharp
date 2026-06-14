# Project 02 Summary - Controller API

## Core Idea

Project 02 introduces Controller-based ASP.NET Core Web API development.

Project 01 used Minimal API:

```csharp
app.MapGet("/users", ...);
```

Project 02 uses Controller API:

```csharp
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
}
```

The purpose is to learn how enterprise ASP.NET Core projects commonly organize HTTP endpoints.

---

## Mental Model

Controller API request flow:

```text
HTTP Request
    ↓
Routing
    ↓
Controller
    ↓
Action Method
    ↓
Service
    ↓
Result
    ↓
HTTP Response
```

Example:

```text
GET /api/users/1
    ↓
UsersController.GetUserById(1)
    ↓
UserService.GetById(1)
    ↓
Ok(user) or NotFound()
```

---

## Program.cs

Important code:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.MapControllers();

app.Run();
```

### AddControllers

```csharp
builder.Services.AddControllers();
```

Registers Controller support in ASP.NET Core.

Without this, ASP.NET Core will not know how to use Controller classes.

### MapControllers

```csharp
app.MapControllers();
```

Maps attribute-routed Controllers.

This enables routes such as:

```csharp
[Route("api/users")]
[HttpGet]
```

---

## Controller

A Controller is a class that groups related HTTP endpoints.

Example:

```csharp
public class UsersController : ControllerBase
{
}
```

In this project, all user-related APIs are grouped inside:

```text
Controllers/UsersController.cs
```

---

## ControllerBase

```csharp
public class UsersController : ControllerBase
```

`ControllerBase` provides helper methods for Web API responses:

```csharp
Ok(...)
NotFound()
CreatedAtAction(...)
BadRequest(...)
Unauthorized()
Forbid()
```

For Web API projects, use:

```csharp
ControllerBase
```

For MVC views, use:

```csharp
Controller
```

---

## ApiController

```csharp
[ApiController]
```

This attribute tells ASP.NET Core that this class is an API Controller.

It enables API-specific behaviors such as:

- Better model binding
- Automatic validation behavior
- More API-friendly error responses

For modern ASP.NET Core Web API projects, Controllers usually have this attribute.

---

## Route

```csharp
[Route("api/users")]
```

This defines the base route for the Controller.

All actions inside this Controller start with:

```text
/api/users
```

Example:

```csharp
[HttpGet]
```

becomes:

```text
GET /api/users
```

```csharp
[HttpGet("{id:int}")]
```

becomes:

```text
GET /api/users/1
```

---

## Action Methods

An action method is a method inside a Controller that handles an HTTP request.

Example:

```csharp
[HttpGet]
public IActionResult GetUsers()
{
    return Ok(_userService.GetAll());
}
```

This handles:

```text
GET /api/users
```

---

## IActionResult

```csharp
public IActionResult GetUsers()
```

`IActionResult` allows a Controller action to return different HTTP responses.

Examples:

```csharp
return Ok(user);
return NotFound();
return CreatedAtAction(...);
```

This is similar to Spring Boot's:

```java
ResponseEntity<?>
```

---

## Constructor Injection

Controller:

```csharp
private readonly UserService _userService;

public UsersController(UserService userService)
{
    _userService = userService;
}
```

Service registration:

```csharp
builder.Services.AddSingleton<UserService>();
```

ASP.NET Core automatically creates `UserService` and injects it into the Controller constructor.

This is Dependency Injection.

---

## Attribute Routing

Controller-level route:

```csharp
[Route("api/users")]
```

Action-level route:

```csharp
[HttpGet("{id:int}")]
```

Combined route:

```text
GET /api/users/{id}
```

The route constraint:

```csharp
{id:int}
```

means the `id` segment must be an integer.

---

## HTTP Response Helpers

### Ok

```csharp
return Ok(users);
```

Returns:

```text
200 OK
```

### NotFound

```csharp
return NotFound();
```

Returns:

```text
404 Not Found
```

### CreatedAtAction

```csharp
return CreatedAtAction(
    nameof(GetUserById),
    new { id = createdUser.Id },
    createdUser);
```

Returns:

```text
201 Created
```

Also creates a `Location` header pointing to the newly created resource.

---

## Minimal API vs Controller API

### Minimal API

```csharp
app.MapGet("/users", (UserService service) =>
{
    return Results.Ok(service.GetAll());
});
```

Characteristics:

- Endpoint defined in Program.cs
- Function-style
- Less boilerplate
- Good for small APIs

### Controller API

```csharp
[HttpGet]
public IActionResult GetUsers()
{
    return Ok(_userService.GetAll());
}
```

Characteristics:

- Endpoint defined in Controller class
- Object-oriented style
- More structure
- Common in enterprise systems

---

## Java / Spring Boot Comparison

| ASP.NET Core | Spring Boot |
|---|---|
| Controller | Controller |
| `[ApiController]` | `@RestController` |
| `[Route("api/users")]` | `@RequestMapping("/api/users")` |
| `[HttpGet]` | `@GetMapping` |
| `[HttpPost]` | `@PostMapping` |
| `IActionResult` | `ResponseEntity<?>` |
| `Ok(...)` | `ResponseEntity.ok(...)` |
| `NotFound()` | `ResponseEntity.notFound()` |
| Constructor injection | Constructor injection |

---

## Key Takeaways

1. Controller API is the classic enterprise ASP.NET Core Web API style.
2. Controllers group related endpoints into classes.
3. Actions are methods that handle HTTP requests.
4. Attribute routing maps HTTP requests to action methods.
5. `ControllerBase` provides HTTP response helper methods.
6. `IActionResult` allows flexible response types.
7. Constructor injection is the normal way to use services in Controllers.
8. `AddControllers()` and `MapControllers()` are required for Controller-based APIs.

---

## Interview Questions

### What is a Controller?

A class that groups related HTTP endpoints and handles requests.

### What is an Action?

A method inside a Controller that handles a specific HTTP request.

### What does `[ApiController]` do?

It marks the class as an API Controller and enables API-specific behaviors.

### What is `ControllerBase`?

A base class for Web API Controllers that provides response helper methods.

### What is `IActionResult`?

A return type that allows an action to return different HTTP responses.

### What is attribute routing?

A routing style where routes are defined using attributes such as `[Route]`, `[HttpGet]`, and `[HttpPost]`.

### Minimal API vs Controller API?

Minimal API is function-based and lightweight. Controller API is class-based and more structured, commonly used in enterprise projects.
