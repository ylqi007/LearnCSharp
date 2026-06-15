# Project 03 Summary - Dependency Injection

## Core Idea

Dependency Injection is a design pattern where an object's dependencies are provided from the outside instead of being created manually inside the object.

Instead of this:

```csharp
// 不用 DI 的写法
private readonly UserService _userService = new UserService(); 
```
* Controller 自己创建 UserService
* Controller 和 UserService 强绑定
* 以后不好替换
* 不好测试

Use this:

```csharp
private readonly IUserService _userService;

public UsersController(IUserService userService)
{
    _userService = userService;
}
```

ASP.NET Core creates and provides the dependency.

---

## Why Dependency Injection Matters

Dependency Injection helps with:

- Loose coupling
- Testability
- Replaceable implementations
- Centralized object creation
- Cleaner architecture

Without DI, classes often create their own dependencies using `new`.

With DI, classes declare what they need, and the framework provides it.

---

## Mental Model

```text
Controller asks for IUserService
    ↓
ASP.NET Core DI Container checks registrations
    ↓
IUserService maps to UserService
    ↓
Container creates UserService
    ↓
Container injects it into UsersController
```

Request flow:

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

---

## Program.cs

Important registration:

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

Meaning:

```text
When a class needs IUserService,
create and inject UserService.
```

---

## Interface

```csharp
public interface IUserService
{
    List<User> GetAll();

    User? GetById(int id);

    User Add(User user);

    bool Delete(int id);
}
```

The interface defines a contract.

It answers:

```text
What can this service do?
```

It does not answer:

```text
How does this service do it?
```

---

## Implementation

```csharp
public class UserService : IUserService
```

The implementation contains the actual logic.

In this project, the data is stored in memory.

In a future project, the implementation could call a database.

---

## Constructor Injection

```csharp
private readonly IUserService _userService;

public UsersController(IUserService userService)
{
    _userService = userService;
}
```

This is constructor injection.

It is the most common and recommended DI style in ASP.NET Core.

Benefits:

- Required dependencies are explicit
- Dependencies can be marked `readonly`
- Easier to test
- Avoids hidden object creation

---

## Service Lifetimes

| Lifetime | Instance Created | Common Use |
|---|---|---|
| Singleton | Once per application | Config, cache, stateless shared service |
| Scoped | Once per HTTP request | Business services, DbContext |
| Transient | Every time requested | Lightweight stateless services |

---

## AddSingleton

```csharp
builder.Services.AddSingleton<IUserService, UserService>();
```

Creates one instance for the entire application lifetime.

All requests share the same instance.

Be careful with mutable state.

---

## AddScoped

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

Creates one instance per HTTP request.

This is commonly used in Web API applications.

Most services that depend on database access should be scoped.

---

## AddTransient

```csharp
builder.Services.AddTransient<IUserService, UserService>();
```

Creates a new instance every time the service is requested.

Good for lightweight stateless services.

---

## Why Use IUserService Instead of UserService?

Direct dependency:

```csharp
private readonly UserService _userService;
```

Interface dependency:

```csharp
private readonly IUserService _userService;
```

The interface version is better because the Controller does not depend on a concrete implementation.

This allows replacement:

```text
IUserService -> UserService
IUserService -> DatabaseUserService
IUserService -> FakeUserService
```

---

## IoC Container

IoC means Inversion of Control.

Normally:

```text
Class creates its dependencies.
```

With IoC:

```text
Framework creates dependencies and gives them to the class.
```

ASP.NET Core's built-in DI container is the IoC container.

---

## New Endpoint in This Project

Project 03 adds:

```http
DELETE /api/users/{id}
```

Controller action:

```csharp
[HttpDelete("{id:int}")]
public IActionResult DeleteUser(int id)
```

Possible responses:

```text
204 No Content
404 Not Found
```

---

## HTTP Response: NoContent

```csharp
return NoContent();
```

Returns:

```text
204 No Content
```

This is commonly used for successful DELETE operations.

---

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `IUserService` | Service interface |
| `UserService` | Service implementation |
| `AddScoped<IUserService, UserService>()` | `@Service` + DI |
| Constructor injection | Constructor injection |
| DI Container | Spring Container |
| Lifetime | Bean scope |

---

## Common Interview Questions

### What is Dependency Injection?

Dependency Injection is a pattern where dependencies are provided to a class from the outside instead of being created inside the class.

### What is IoC?

Inversion of Control means the framework controls object creation instead of application code manually creating dependencies.

### Why depend on an interface?

To reduce coupling, improve testability, and allow replacing implementations.

### What is AddScoped?

It registers a service so that one instance is created per HTTP request.

### AddSingleton vs AddScoped vs AddTransient?

Singleton creates one instance for the entire app.

Scoped creates one instance per HTTP request.

Transient creates a new instance every time it is requested.

### Why is Scoped common for Web APIs?

Because many Web API services work within a request boundary and often depend on scoped resources such as database contexts.

---

## Key Takeaways

1. Dependency Injection is central to ASP.NET Core.
2. Controllers should depend on abstractions when appropriate.
3. Interfaces define contracts.
4. Implementations contain logic.
5. `Program.cs` registers service mappings.
6. Constructor injection is the standard DI pattern.
7. `AddScoped` is the most common lifetime for Web API business services.
8. DI improves testability and maintainability.
