# Project 04 - Options Pattern

## Objective

This project introduces the ASP.NET Core Options Pattern.

In previous projects, many values were hardcoded in C# code. In this project, application behavior is controlled by configuration from `appsettings.json`.

The goal is to learn how to bind configuration into strongly typed C# classes and inject those settings into services.

## Learning Goals

- Understand `appsettings.json`
- Create an Options class
- Bind configuration with `Configure<TOptions>()`
- Inject settings with `IOptions<T>`
- Avoid raw string configuration lookups
- Compare ASP.NET Core configuration with Spring Boot configuration

## Project Structure

```text
04-options-pattern/
├── 04-options-pattern.csproj
├── appsettings.json
├── Program.cs
├── Controllers/
│   └── UsersController.cs
├── Models/
│   └── User.cs
├── Options/
│   └── UserSettingsOptions.cs
├── Services/
│   ├── IUserService.cs
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

## Architecture

```text
appsettings.json
    ↓
UserSettingsOptions
    ↓
IOptions<UserSettingsOptions>
    ↓
UserService
    ↓
UsersController
```

## Configuration

`appsettings.json`:

```json
{
  "UserSettings": {
    "DefaultPageSize": 2,
    "AllowUserCreation": true,
    "DefaultEmailDomain": "example.com"
  }
}
```

## Program.cs

```csharp
builder.Services.Configure<UserSettingsOptions>(
    builder.Configuration.GetSection(UserSettingsOptions.SectionName));
```

This means:

```text
Find the UserSettings section in appsettings.json
and bind it to UserSettingsOptions.
```

## Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/` | Root greeting |
| GET | `/api/users` | Get all users |
| GET | `/api/users/paged` | Get users limited by configured page size |
| GET | `/api/users/{id}` | Get one user |
| POST | `/api/users` | Create user using configured behavior |

## Behavior Controlled by Configuration

`DefaultPageSize` controls how many users are returned from `/api/users/paged`.

`AllowUserCreation` controls whether POST `/api/users` is allowed.

`DefaultEmailDomain` is used when creating a user without an email.

## Running

```bash
dotnet restore
dotnet run
```

Update `@host` in `test.http` if your local port is different.

## Why Options Pattern?

Avoid this:

```csharp
string? value = builder.Configuration["UserSettings:DefaultPageSize"];
```

Prefer this:

```csharp
IOptions<UserSettingsOptions>
```

Benefits:

- Strong typing
- Centralized configuration model
- Easier testing
- Easier refactoring
- Cleaner service code

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `appsettings.json` | `application.yml` / `application.properties` |
| `UserSettingsOptions` | `@ConfigurationProperties` class |
| `Configure<TOptions>()` | configuration binding |
| `IOptions<T>` | injected configuration properties bean |
| `builder.Configuration` | Spring Environment |

## What Comes Next

Project 05 will introduce Middleware and the ASP.NET Core request pipeline.


## Appendix
### 1. 为什么需要 Options Pattern？
假设你在代码里写死：

```csharp
private const int DefaultPageSize = 2;
private const string DefaultEmailDomain = "example.com";
```

问题是：
* 改配置必须改代码
* 改代码必须重新 build
* 不同环境不好切换
* 配置散落在代码中
* 测试不方便


