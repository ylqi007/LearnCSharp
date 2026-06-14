# Project 01 - Minimal API

## Objective

This project introduces ASP.NET Core Minimal API and demonstrates how to build a lightweight HTTP service without using Controllers.

The goal is to understand:

* ASP.NET Core application startup
* Routing
* HTTP GET and POST endpoints
* Dependency Injection (DI)
* JSON serialization/deserialization
* Basic service layer separation

This project represents the transition from Console Applications to Web Applications.

---

## Project Structure

```text
01-minimal-api/
├── 01-minimal-api.csproj
├── Program.cs
├── Models/
│   └── User.cs
├── Services/
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

### Program.cs

Application startup entry point.

Responsible for:

* Creating the WebApplicationBuilder
* Registering services
* Configuring endpoints
* Starting the web server

### Models

Contains domain models.

Current model:

* User

### Services

Contains business logic.

Current service:

* UserService

---

## Architecture

```text
Client
  ↓
HTTP Request
  ↓
Minimal API Endpoint
  ↓
UserService
  ↓
Model
  ↓
JSON Response
```

---

## Endpoints

### GET /

Returns a simple greeting.

Response:

```text
Hello Minimal API
```

---

### GET /users

Returns all users.

Response:

```json
[
  {
    "id": 1,
    "name": "Alice",
    "email": "alice@example.com"
  }
]
```

---

### POST /users

Creates a new user.

Request:

```json
{
  "id": 3,
  "name": "Charlie",
  "email": "charlie@example.com"
}
```

Response:

```json
{
  "id": 3,
  "name": "Charlie",
  "email": "charlie@example.com"
}
```

Status Code:

```text
201 Created
```

---

## Running the Project

```bash
dotnet restore
dotnet run
```

Example output:

```text
Now listening on:
http://localhost:5118
```

---

## Testing

### REST Client

Install:

```text
REST Client (VS Code Extension)
```

Run requests from:

```text
test.http
```

### curl

```bash
curl http://localhost:5118/users
```

---

## Key Concepts

### Minimal API

A lightweight approach introduced in ASP.NET Core for defining HTTP endpoints without Controllers.

### Dependency Injection

ASP.NET Core automatically creates and injects services.

Example:

```csharp
(UserService service)
```

### JSON Model Binding

ASP.NET Core automatically converts request JSON into C# objects.

### Service Layer

Business logic is kept inside services instead of endpoint handlers.

---

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot      |
| ------------ | ---------------- |
| Program.cs   | Application.java |
| MapGet       | @GetMapping      |
| MapPost      | @PostMapping     |
| AddSingleton | Singleton Bean   |
| UserService  | Service          |
| DI Container | Spring Container |

---

## What Comes Next

Project 02 introduces Controllers and compares:

```text
Minimal API
vs
Controller API
```