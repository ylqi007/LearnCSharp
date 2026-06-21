# Project 10 - Health Checks

## Objective

This project introduces Health Checks in ASP.NET Core.

Health checks are used by load balancers, orchestrators, Kubernetes, monitoring systems, and deployment platforms to understand whether an application is alive and ready to serve traffic.

---

## Learning Goals

After completing this project, you should understand:

- What health checks are
- Why production systems need health checks
- The difference between liveness and readiness
- How to register health checks with `AddHealthChecks()`
- How to expose health check endpoints with `MapHealthChecks()`
- How to write custom health checks using `IHealthCheck`
- How health checks relate to Kubernetes probes
- How dependency health affects readiness

---

## Project Structure

```text
10-health-checks/
├── 10-health-checks.csproj
├── appsettings.json
├── Program.cs
├── Controllers/
│   ├── DemoDependencyController.cs
│   └── UsersController.cs
├── HealthChecks/
│   ├── DatabaseHealthCheck.cs
│   ├── ExternalApiHealthCheck.cs
│   └── SelfHealthCheck.cs
├── Models/
│   └── User.cs
├── Services/
│   ├── DemoDependencyOptions.cs
│   ├── DemoDependencyStatus.cs
│   ├── IDemoDependencyStatus.cs
│   ├── IUserService.cs
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

---

## Core Idea

Health checks answer two important questions:

```text
Is the app process running?
Is the app ready to serve real traffic?
```

These are related but different.

---

## Liveness vs Readiness

### Liveness

Liveness answers:

```text
Is the process alive?
```

Endpoint:

```http
GET /health/live
```

If liveness fails, an orchestrator may restart the app.

---

### Readiness

Readiness answers:

```text
Can this app instance serve traffic right now?
```

Endpoint:

```http
GET /health/ready
```

If readiness fails, an orchestrator may stop sending traffic to the app without restarting it.

---

## Endpoints

| Endpoint | Purpose |
|---|---|
| `/health` | Full health report |
| `/health/live` | Liveness check |
| `/health/ready` | Readiness check |

---

## Health Checks in Program.cs

```csharp
builder.Services
    .AddHealthChecks()
    .AddCheck<SelfHealthCheck>(
        "self",
        tags: ["live"])
    .AddCheck<DatabaseHealthCheck>(
        "database",
        failureStatus: HealthStatus.Unhealthy,
        tags: ["ready"])
    .AddCheck<ExternalApiHealthCheck>(
        "external-api",
        failureStatus: HealthStatus.Degraded,
        tags: ["ready"]);
```

Tags are used to separate liveness and readiness checks.

---

## Custom Health Check

Each custom health check implements:

```csharp
IHealthCheck
```

and defines:

```csharp
Task<HealthCheckResult> CheckHealthAsync(...)
```

Possible results:

```text
Healthy
Degraded
Unhealthy
```

---

## Demo Dependency Controller

This project includes a demo controller that lets you simulate dependencies going up and down:

```http
POST /api/demo-dependencies/database/false
POST /api/demo-dependencies/external-api/false
```

Then check:

```http
GET /health/ready
```

---

## Running

```bash
dotnet restore
dotnet run
```

Then test requests in:

```text
test.http
```

---

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| Health Checks | Spring Boot Actuator Health |
| `IHealthCheck` | `HealthIndicator` |
| `/health/live` | Liveness probe |
| `/health/ready` | Readiness probe |
| `Healthy` | UP |
| `Unhealthy` | DOWN |
| `Degraded` | OUT_OF_SERVICE / custom status |

---

## What Comes Next

This completes Phase 2 - ASP.NET Core.

The next phase is Phase 3 - Entity Framework Core.


---

## 10 Health Checks

### Goal

Learn how production systems determine whether an application is alive and ready to receive traffic.

---

### Topics

* Health Checks
* Liveness
* Readiness
* IHealthCheck
* HealthCheckResult
* Health Status Design
* Production Monitoring
* Kubernetes Probes

---

### Why Health Checks Matter

Production platforms need a way to determine:

```text
Is the application running?

Can it receive traffic?

Are its dependencies healthy?
```

Health Checks provide standardized endpoints to answer these questions.

---

### Liveness vs Readiness

#### Liveness

Question:

```text
Is the application process alive?
```

Endpoint:

```text
/health/live
```

If liveness fails:

```text
Platform may restart the application.
```

---

#### Readiness

Question:

```text
Can this instance currently serve traffic?
```

Endpoint:

```text
/health/ready
```

If readiness fails:

```text
Platform stops sending traffic
but does not necessarily restart the process.
```

---

### Health Status

ASP.NET Core supports three health states:

```text
Healthy
Degraded
Unhealthy
```

Healthy:

* Everything is working.

Degraded:

* Application still works but functionality is partially impaired.

Unhealthy:

* Application cannot correctly serve requests.

---

### Custom Health Checks

Custom health checks implement:

```csharp
IHealthCheck
```

and return:

```csharp
HealthCheckResult
```

Examples:

```text
DatabaseHealthCheck
RedisHealthCheck
ServiceBusHealthCheck
ExternalApiHealthCheck
```

---

### Key Design Principle

Dependencies usually belong in Readiness checks.

Examples:

```text
Database
Redis
Message Queue
External APIs
```

Avoid placing critical dependency checks in Liveness probes.

---

### Kubernetes Mental Model

```text
Liveness fails
    ↓
Restart container

Readiness fails
    ↓
Remove instance from traffic
```

---

### Key Takeaways

1. Health Checks are production endpoints.
2. Liveness and Readiness serve different purposes.
3. Health Checks integrate with Kubernetes and cloud platforms.
4. Dependencies usually belong in Readiness checks.
5. Custom checks implement IHealthCheck.
6. ASP.NET Core supports Healthy, Degraded, and Unhealthy states.
7. Health Checks are part of application operability, not business logic.
