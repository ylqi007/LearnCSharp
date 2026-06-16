# Project 07 Summary - Configuration

## Core Idea

ASP.NET Core configuration is not just `appsettings.json`.

It is a unified system that combines multiple configuration providers into one `IConfiguration`.

## Configuration Providers

Common providers:

```text
appsettings.json
appsettings.{Environment}.json
User Secrets
Environment Variables
Command Line Arguments
Azure App Configuration
Azure Key Vault
```

## Default Loading

When you call:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

ASP.NET Core automatically loads common configuration providers.

## Provider Precedence

Later providers can override earlier providers.

Typical order:

```text
appsettings.json
    ↓
appsettings.Development.json
    ↓
User Secrets
    ↓
Environment Variables
    ↓
Command Line Arguments
```

If the same key appears in multiple places, the later provider wins.

## appsettings.json

Base configuration.

Good for values common to all environments.

## appsettings.Development.json

Environment-specific override.

When running in Development, this overrides the base value.

## Environment Name

ASP.NET Core uses the environment name to decide which environment-specific file to load.

Common values:

```text
Development
Staging
Production
```

The current environment is available through:

```csharp
IWebHostEnvironment environment
```

## IConfiguration

`IConfiguration` is the raw configuration abstraction.

Example:

```csharp
_configuration["Application:Name"]
```

Nested keys use colon syntax:

```text
Application:Name
UserSettings:DefaultPageSize
ExternalServices:TimeoutSeconds
```

## Environment Variables

Nested keys use double underscores:

```bash
export UserSettings__DefaultPageSize=5
```

This maps to:

```text
UserSettings:DefaultPageSize
```

## Command-Line Arguments

```bash
dotnet run --UserSettings:DefaultPageSize=10
```

## Raw IConfiguration vs IOptions<T>

| Approach | Good For |
|---|---|
| `IConfiguration` | Quick reads, diagnostics, dynamic key lookup |
| `IOptions<T>` | Strongly typed service configuration |
| `IOptionsSnapshot<T>` | Per-request refreshed configuration |
| `IOptionsMonitor<T>` | Change monitoring and singleton-friendly config |

For business services, prefer `IOptions<T>`.

## Key Experiment

Run normally:

```bash
dotnet run
```

Then check:

```http
GET /api/configuration
```

Override with environment variable:

```bash
export UserSettings__DefaultPageSize=5
dotnet run
```

Override with command line:

```bash
dotnet run --UserSettings:DefaultPageSize=10
```

Command line should win.

## Interview Questions

### What is IConfiguration?

The unified abstraction over all configuration sources.

### Is appsettings.json mandatory?

No. It is a default convention loaded by `WebApplication.CreateBuilder(args)`.

### How do environment-specific settings work?

ASP.NET Core loads `appsettings.{Environment}.json` based on the current environment.

### How do environment variables represent nested keys?

Use double underscores.

### What happens if the same key exists in multiple providers?

The provider with higher precedence wins.

## Key Takeaways

1. Configuration is a provider-based system.
2. `appsettings.json` is only one configuration source.
3. Environment-specific files override base settings.
4. Environment variables can override JSON settings.
5. Command-line arguments can override both.
6. `IConfiguration` gives raw access.
7. `IOptions<T>` gives strongly typed access.
8. Understanding configuration precedence is essential for production systems.
