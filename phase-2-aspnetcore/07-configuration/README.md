# Project 07 - Configuration

## Objective

This project introduces ASP.NET Core configuration in more depth.

Project 04 introduced the Options Pattern. Project 07 focuses on where configuration values come from and how ASP.NET Core combines multiple configuration providers.

## Learning Goals

- `IConfiguration`
- `appsettings.json`
- `appsettings.{Environment}.json`
- environment-specific configuration
- environment variables
- command-line arguments
- configuration provider precedence
- strongly typed options
- raw configuration access

## Project Structure

```text
07-configuration/
├── 07-configuration.csproj
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── Controllers/
│   ├── ConfigurationController.cs
│   └── UsersController.cs
├── Models/
│   └── User.cs
├── Options/
│   ├── ApplicationOptions.cs
│   ├── ExternalServicesOptions.cs
│   └── UserSettingsOptions.cs
├── Services/
│   ├── ConfigurationReporter.cs
│   ├── IConfigurationReporter.cs
│   ├── IUserService.cs
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

## Core Idea

ASP.NET Core configuration is built from multiple sources:

```text
appsettings.json
appsettings.Development.json
Environment Variables
Command Line Arguments
User Secrets
Azure App Configuration
Key Vault
```

Later sources can override earlier sources.

## Configuration Flow

```text
Configuration Providers
    ↓
IConfiguration
    ↓
Options Binding
    ↓
IOptions<T>
    ↓
Services / Controllers
```

## Configuration Report Endpoint

```http
GET /api/configuration
```

Returns:

- current environment
- raw configuration values
- strongly typed options values

## Environment Variables

Nested keys use double underscores:

```bash
export UserSettings__DefaultPageSize=5
export ExternalServices__TimeoutSeconds=20
```

Then run:

```bash
dotnet run
```

## Command-Line Arguments

```bash
dotnet run --UserSettings:DefaultPageSize=10
```

Command-line arguments usually have higher priority than JSON files.

## Running

```bash
dotnet restore
dotnet run
```

Then test:

```http
GET /api/configuration
```

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `appsettings.json` | `application.yml` |
| `appsettings.Development.json` | `application-dev.yml` |
| `IConfiguration` | `Environment` |
| Options class | `@ConfigurationProperties` |
| Environment variables | Environment variables |
| Command-line args | Command-line args |
| Provider precedence | Property source precedence |

## What Comes Next

Project 08 will introduce Global Exception Handling.
