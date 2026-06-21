# Project 10 Summary - Health Checks

## Core Idea

Health checks are production endpoints that report whether an application is alive and ready to serve traffic.

They are used by:

- load balancers
- Kubernetes
- Azure App Service
- monitoring systems
- deployment platforms
- incident response tooling

---

## Liveness

Liveness answers:

```text
Is the application process alive?
```

Endpoint:

```http
GET /health/live
```

If liveness fails, the platform may restart the process.

Liveness should usually check only the application process itself.

It should not depend heavily on external services.

---

## Readiness

Readiness answers:

```text
Can this application instance serve traffic right now?
```

Endpoint:

```http
GET /health/ready
```

If readiness fails, the platform should stop sending traffic to this instance.

Readiness can check dependencies such as:

- database
- cache
- message broker
- downstream services

---

## Full Health Report

Endpoint:

```http
GET /health
```

This returns all registered health checks.

In this project, it includes:

- self
- database
- external-api

---

## AddHealthChecks

```csharp
builder.Services
    .AddHealthChecks()
    .AddCheck<SelfHealthCheck>("self", tags: ["live"])
    .AddCheck<DatabaseHealthCheck>("database", tags: ["ready"])
    .AddCheck<ExternalApiHealthCheck>("external-api", tags: ["ready"]);
```

This registers health checks in DI.

---

## MapHealthChecks

```csharp
app.MapHealthChecks("/health/live", ...);
app.MapHealthChecks("/health/ready", ...);
app.MapHealthChecks("/health", ...);
```

This exposes health check endpoints.

---

## Tags

Tags are used to group checks.

In this project:

```text
live
    self

ready
    database
    external-api
```

This allows separate endpoints for liveness and readiness.

---

## IHealthCheck

Custom health checks implement:

```csharp
public interface IHealthCheck
{
    Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default);
}
```

Each health check returns:

```text
Healthy
Degraded
Unhealthy
```

---

## HealthCheckResult

Examples:

```csharp
HealthCheckResult.Healthy("Database is available.")
HealthCheckResult.Degraded("External API is slow.")
HealthCheckResult.Unhealthy("Database is unavailable.")
```

---

## DatabaseHealthCheck

Checks whether the simulated database is available.

If available:

```text
Healthy
```

If unavailable:

```text
Unhealthy
```

This affects readiness.

---

## ExternalApiHealthCheck

Checks whether the simulated external API is available.

If available:

```text
Healthy
```

If unavailable:

```text
Degraded
```

This means the app may still partially work, but some functionality is impaired.

---

## DemoDependencyController

Allows tests to simulate dependency failures.

Examples:

```http
POST /api/demo-dependencies/database/false
POST /api/demo-dependencies/external-api/false
```

This is only for learning/demo purposes.

In real systems, dependencies are checked by actually calling the dependency.

---

## Response Writer

The project customizes health response JSON with:

```csharp
ResponseWriter = WriteHealthResponseAsync
```

This returns:

- overall status
- total duration
- individual check status
- descriptions
- data

---

## Kubernetes Mental Model

```text
Liveness failure
    ↓
Restart container

Readiness failure
    ↓
Remove instance from traffic
```

This distinction is critical in production.

---

## Production Guidance

Good liveness check:

```text
Is process running?
Can the app respond?
```

Bad liveness check:

```text
Can the database respond?
Can every downstream dependency respond?
```

Reason:

If database fails and every app instance restarts repeatedly, the system may become worse.

Dependency checks usually belong in readiness, not liveness.

---

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| Health Checks | Actuator Health |
| `IHealthCheck` | `HealthIndicator` |
| `/health/live` | Liveness probe |
| `/health/ready` | Readiness probe |
| Healthy | UP |
| Unhealthy | DOWN |
| Degraded | custom / OUT_OF_SERVICE |

---

## Interview Questions

### What is a health check?

An endpoint or component that reports whether an application or dependency is healthy.

### What is liveness?

Whether the process is alive and should keep running.

### What is readiness?

Whether the instance is ready to receive production traffic.

### Why should liveness avoid dependency checks?

Because dependency failures should not usually cause all app instances to restart.

### What is IHealthCheck?

The ASP.NET Core interface for implementing custom health checks.

### What are tags used for?

To group checks and expose different health endpoints.

---

## Key Takeaways

1. Health checks are production readiness features.
2. Liveness and readiness are different.
3. Liveness checks process health.
4. Readiness checks traffic-serving ability.
5. Dependencies usually belong in readiness checks.
6. Custom checks implement `IHealthCheck`.
7. Tags separate different health endpoints.
8. Health checks are critical for Kubernetes and cloud deployment.
