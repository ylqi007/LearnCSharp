# Project 03 - Dependency Injection

## Objective

This project introduces Dependency Injection in ASP.NET Core in a more explicit way.

In Project 02, the Controller depended directly on a concrete class:

```csharp
private readonly UserService _userService;
```

In this project, the Controller depends on an abstraction:

```csharp
private readonly IUserService _userService;
```

The goal is to understand why ASP.NET Core applications commonly use interfaces, constructor injection, and service lifetime registrations.

---

## Learning Goals

After completing this project, you should understand:

- What Dependency Injection is
- What an IoC Container is
- Why Controllers often depend on abstractions
- How to register services in `Program.cs`
- How constructor injection works
- The difference between `AddSingleton`, `AddScoped`, and `AddTransient`
- Why `AddScoped` is commonly used in Web API services

---

## Project Structure

```text
03-dependency-injection/
├── 03-dependency-injection.csproj
├── Program.cs
├── Controllers/
│   └── UsersController.cs
├── Models/
│   └── User.cs
├── Services/
│   ├── IUserService.cs
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

---

## Architecture

```text
HTTP Request
    ↓
UsersController
    ↓
IUserService
    ↓
UserService
    ↓
HTTP Response
```

The Controller only knows about `IUserService`.

It does not need to know which concrete implementation is being used.

---

## Key Files

### Program.cs

Important line:

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

Meaning:

```text
When something asks for IUserService,
provide an instance of UserService.
```

---

### Services/IUserService.cs

Defines the contract:

```csharp
public interface IUserService
{
    List<User> GetAll();

    User? GetById(int id);

    User Add(User user);

    bool Delete(int id);
}
```

The interface describes what the service can do, but not how it does it.

---

### Services/UserService.cs

Implements the interface:

```csharp
public class UserService : IUserService
```

This class contains the actual business logic.

---

### Controllers/UsersController.cs

Depends on the interface:

```csharp
private readonly IUserService _userService;

public UsersController(IUserService userService)
{
    _userService = userService;
}
```

This is constructor injection.

---

## Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/` | Root greeting |
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get one user |
| POST | `/api/users` | Create user |
| DELETE | `/api/users/{id}` | Delete user |

---

## Service Lifetimes

### Singleton

```csharp
builder.Services.AddSingleton<IUserService, UserService>();
```

One instance for the entire application lifetime.

Good for configuration, caches, and stateless shared services.

Be careful with mutable state.

---

### Scoped

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

One instance per HTTP request.

This is the most common lifetime for Web API business services and database-related services.

---

### Transient

```csharp
builder.Services.AddTransient<IUserService, UserService>();
```

A new instance every time it is requested.

Good for lightweight stateless services.

---

## Why Use Interfaces?

Instead of this:

```csharp
private readonly UserService _userService;
```

Use this:

```csharp
private readonly IUserService _userService;
```

Benefits:

- Lower coupling
- Easier unit testing
- Easier to replace implementation
- Cleaner architecture

Later, the implementation could be replaced without changing the Controller:

```text
IUserService -> UserService
IUserService -> DatabaseUserService
IUserService -> FakeUserService
```

---

## Testing

Run:

```bash
dotnet restore
dotnet run
```

Then open `test.http` in VS Code and use REST Client.

Update the `@host` value if your local port is different.

---

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `IUserService` | Service interface |
| `UserService` | Service implementation |
| `AddScoped<IUserService, UserService>()` | `@Service` registration |
| Constructor injection | Constructor injection |
| DI Container | Spring Container |
| Service lifetime | Bean scope |

---

## What Comes Next

Project 04 will introduce the Options Pattern.

It will show how ASP.NET Core binds configuration from `appsettings.json` into strongly typed C# classes.
