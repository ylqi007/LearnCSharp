# Project 12 - Dependency Injection Preview

## Goal
Understand the core idea behind dependency injection before learning ASP.NET Core.

## Concepts
- Tight coupling vs loose coupling
- Interfaces as contracts
- Constructor injection
- Fake/mock dependencies for testing
- Inversion of Control
- Mini DI container preview
- ASP.NET Core DI lifetime preview: Singleton, Scoped, Transient

## Java Comparison
Java Spring commonly uses constructor injection:

```java
public UserService(UserRepository repo) { ... }
```

C# ASP.NET Core uses the same idea:

```csharp
public UserService(IUserRepository repo) { ... }
```

Later, ASP.NET Core will create and inject dependencies automatically.

## Run

```bash
dotnet run --project src/DependencyInjectionDemo/DependencyInjectionDemo.csproj
```

## Examples
- Example01: Tight coupling
- Example02: Constructor injection
- Example03: Fake dependency for testing
- Example04: Notification service with multiple dependencies
- Example05: Mini DI container
- Example06: Lifetime preview

## Key Takeaways
- Classes should depend on abstractions, not concrete details.
- Constructor injection makes dependencies explicit.
- DI improves testability.
- ASP.NET Core is built around DI.
