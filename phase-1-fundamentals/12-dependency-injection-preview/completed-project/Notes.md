# Completed Project Notes - Project 12

## What You Learned
- Tight coupling happens when a class creates its own concrete dependencies.
- Constructor injection makes dependencies explicit.
- Interfaces make code replaceable and testable.
- Fake dependencies are useful for tests and demos.
- ASP.NET Core DI will automate object construction later.

## Java Comparison
This is very close to Spring constructor injection.

Java/Spring:

```java
@Service
public class UserService {
    private final UserRepository repo;
    public UserService(UserRepository repo) { this.repo = repo; }
}
```

C#:

```csharp
public sealed class UserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) { _repo = repo; }
}
```

## Best Practices
- Prefer constructor injection.
- Depend on interfaces when replacement/testing is valuable.
- Avoid service locator style in application code.
- Keep object lifetimes in mind.
