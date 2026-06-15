# Project 04 Summary - Options Pattern

## Core Idea

The Options Pattern is the standard ASP.NET Core way to read configuration into strongly typed classes.

Instead of scattering configuration string lookups throughout the codebase, define a class that represents a configuration section and inject it where needed.

## Problem

Without Options Pattern:

```csharp
string? pageSize = builder.Configuration["UserSettings:DefaultPageSize"];
```

Problems:

- String keys are easy to mistype
- Values need manual conversion
- No clear configuration contract
- Harder to refactor
- Harder to test

## Solution

Use a strongly typed Options class:

```csharp
public class UserSettingsOptions
{
    public const string SectionName = "UserSettings";

    public int DefaultPageSize { get; set; }

    public bool AllowUserCreation { get; set; }

    public string DefaultEmailDomain { get; set; } = string.Empty;
}
```

Bind it in `Program.cs`:

```csharp
builder.Services.Configure<UserSettingsOptions>(
    builder.Configuration.GetSection(UserSettingsOptions.SectionName));
```

Inject it into services:

```csharp
public UserService(IOptions<UserSettingsOptions> options)
{
    _settings = options.Value;
}
```

## Mental Model

```text
appsettings.json
    ↓
Configuration System
    ↓
UserSettingsOptions
    ↓
IOptions<UserSettingsOptions>
    ↓
UserService
```

## Key Files

### appsettings.json

Stores external configuration.

### UserSettingsOptions.cs

Strongly typed class representing the `UserSettings` section.

### Program.cs

Binds configuration to the Options class.

### UserService.cs

Consumes settings through `IOptions<UserSettingsOptions>`.

## Configure<TOptions>

```csharp
builder.Services.Configure<UserSettingsOptions>(
    builder.Configuration.GetSection(UserSettingsOptions.SectionName));
```

This tells ASP.NET Core to bind the `UserSettings` section to `UserSettingsOptions`.

## IOptions<T>

```csharp
IOptions<UserSettingsOptions>
```

This is injected by ASP.NET Core.

Use:

```csharp
options.Value
```

to access the settings object.

## Configuration-Controlled Behavior

`DefaultPageSize` controls `/api/users/paged`.

`AllowUserCreation` controls whether POST `/api/users` is allowed.

`DefaultEmailDomain` generates an email when no email is provided.

## IOptions vs IOptionsSnapshot vs IOptionsMonitor

| Type | Meaning |
|---|---|
| `IOptions<T>` | Basic options, simple and stable config |
| `IOptionsSnapshot<T>` | Scoped, useful for per-request refreshed config |
| `IOptionsMonitor<T>` | Singleton-friendly, supports change notifications |

For Project 04, only `IOptions<T>` is required.

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `appsettings.json` | `application.yml` |
| Options class | `@ConfigurationProperties` |
| `Configure<TOptions>()` | configuration binding |
| `IOptions<T>` | injected configuration bean |
| `builder.Configuration` | Spring Environment |

## Interview Questions

### What is the Options Pattern?

A pattern for binding configuration sections to strongly typed classes and injecting them into services.

### Why use Options Pattern?

It avoids raw string configuration lookups and provides strong typing, cleaner code, and easier testing.

### What is `IOptions<T>`?

A wrapper that provides access to a configured options instance through `.Value`.

### Where is configuration registered?

Usually in `Program.cs` using `builder.Services.Configure<TOptions>(...)`.

### What is `appsettings.json`?

The default JSON configuration file used by ASP.NET Core applications.

## Key Takeaways

1. Configuration should not be hardcoded.
2. `appsettings.json` stores application settings.
3. Options classes represent configuration sections.
4. `Configure<TOptions>()` binds configuration to classes.
5. `IOptions<T>` injects configuration into services.
6. Strongly typed configuration is safer than raw string lookups.
7. Options Pattern is widely used in production ASP.NET Core applications.
