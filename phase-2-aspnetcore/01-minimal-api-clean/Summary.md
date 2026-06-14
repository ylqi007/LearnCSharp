# Project 01 Summary - Minimal API

## What I Learned

This project introduced ASP.NET Core Minimal API and demonstrated how to expose HTTP endpoints without using Controllers.

The project focused on:

* WebApplicationBuilder
* Dependency Injection
* Routing
* HTTP GET / POST
* JSON Serialization
* Service Layer Separation

---

# Mental Model

Console Application:

```text
Program
  ↓
Output
```

ASP.NET Core Web API:

```text
HTTP Request
  ↓
Routing
  ↓
Endpoint
  ↓
Service
  ↓
Response
```

The biggest mindset shift is moving from executing a program once to handling requests continuously.

---

# Startup Flow

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.MapGet(...);

app.Run();
```

Execution Flow:

```text
CreateBuilder
    ↓
Register Services
    ↓
Build Application
    ↓
Configure Routes
    ↓
Run Web Server
```

---

# Dependency Injection

Registration:

```csharp
builder.Services.AddSingleton<UserService>();
```

Usage:

```csharp
(UserService service)
```

Benefits:

* Loose coupling
* Easier testing
* Centralized object creation

Important:

```text
Do not manually create dependencies using new.
```

Preferred:

```csharp
(UserService service)
```

---

# Singleton Lifetime

```csharp
AddSingleton<T>()
```

Characteristics:

* One instance per application
* Shared across requests
* Good for stateless services

Future lifetimes:

```csharp
AddSingleton()
AddScoped()
AddTransient()
```

---

# Routing

GET endpoint:

```csharp
app.MapGet("/users", ...);
```

POST endpoint:

```csharp
app.MapPost("/users", ...);
```

Routing maps:

```text
HTTP Request
    ↓
Matching Endpoint
```

---

# JSON Model Binding

Request:

```json
{
  "id": 3,
  "name": "Charlie"
}
```

Automatically converted to:

```csharp
User user
```

This process is called:

```text
Model Binding
```

---

# HTTP Status Codes

Success:

```csharp
Results.Ok(...)
```

Returns:

```text
200 OK
```

Creation:

```csharp
Results.Created(...)
```

Returns:

```text
201 Created
```

Common codes:

| Code | Meaning               |
| ---- | --------------------- |
| 200  | Success               |
| 201  | Created               |
| 400  | Bad Request           |
| 401  | Unauthorized          |
| 403  | Forbidden             |
| 404  | Not Found             |
| 500  | Internal Server Error |

---

# Minimal API vs Controller

Minimal API

Pros:

* Less code
* Easy to learn
* Fast prototyping

Cons:

* Can become messy as APIs grow

Controller

Pros:

* Better organization
* More common in enterprise projects

Cons:

* More boilerplate

---

# Interview Notes

### What is Minimal API?

A lightweight way to define HTTP endpoints without Controllers.

---

### What is Dependency Injection?

A design pattern where dependencies are provided by the framework instead of being manually instantiated.

---

### What is the purpose of AddSingleton?

Creates a single instance for the application's lifetime.

---

### How does ASP.NET Core convert JSON into C# objects?

Through Model Binding.

---

### What is the responsibility of Program.cs?

* Application startup
* Service registration
* Route configuration
* Server initialization

---

# Java Mapping

| ASP.NET Core | Spring Boot      |
| ------------ | ---------------- |
| Program.cs   | Application.java |
| MapGet       | @GetMapping      |
| MapPost      | @PostMapping     |
| UserService  | Service          |
| AddSingleton | Singleton Bean   |
| DI Container | Spring Container |

---

# Key Takeaways

1. ASP.NET Core applications are request-driven.
2. Minimal API provides a lightweight endpoint model.
3. Dependency Injection is a first-class feature in ASP.NET Core.
4. Services should contain business logic.
5. Program.cs acts as the application bootstrapper.
6. JSON serialization and model binding happen automatically.
7. Routing maps HTTP requests to endpoint handlers.
