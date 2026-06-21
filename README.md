# LearnCSharp

My journey of learning modern C#, .NET, ASP.NET Core, and Azure Identity.

## Goals

* Become proficient in modern C# development
* Learn .NET and ASP.NET Core from fundamentals to production systems
* Understand Azure SDKs and Azure Identity
* Build a long-term personal knowledge base
* Bridge Java backend experience to the Microsoft ecosystem

---

## Progress

### Fundamentals

| Status | Project                  |
| ------ | ------------------------ |
| ✅      | 01-console-basics        |
| ✅      | 02-types-and-nullability |
| ✅      | 03-oop                   |
| ✅      | 04-generics              |
| ✅      | 05-collections           |
| ✅      | 06-linq                  |
| ✅      | 07-records               |
| ✅      | 08-exceptions            |
| ✅      | 09-delegates-and-events  |
| ✅      | 10-async-await           |
| ✅      | 11-extension-methods     |
| ✅      | 12-dependency-injection-preview  |


---

## Repository Structure

```text
LearnCSharp
├── notes
├── fundamentals
├── dotnet
├── aspnet-core
├── data-access
└── azure-identity
```

---

## Completed Projects

### 01-console-basics

Topics:

* Program.cs
* Top-level Statements
* Classes
* Properties
* Collections
* Build / Run / Debug

---

### 02-types-and-nullability

Topics:

* Nullable Reference Types
* string vs string?
* required
* ?.
* ??
* !
* Nullable Flow Analysis

---

### 03-oop

Topics:

* Class
* Constructor
* Property
* Inheritance
* Interface
* Abstract Class
* Record
* Init-only Property

---

### 04-generics

Topics:

* Generic Collections
* Generic Methods
* Generic Classes
* Generic Interfaces
* Generic Repositories
* Generic Constraints
* `where T : class`
* `where T : new()`
* `where T : IEntity`

Key Takeaways:

* Generics enable reusable and type-safe code.
* `T` represents a type parameter that is supplied later.
* Generic methods, classes, and interfaces eliminate duplicate implementations.
* Generic constraints restrict what types can be used.
* `where T : new()` allows creating instances with `new T()`.
* `where T : IEntity` guarantees required members are available.
* Repository patterns commonly rely on generics for code reuse.
* C# uses reified generics, preserving type information at runtime.
* Generics are foundational to LINQ, Dependency Injection, ASP.NET Core, Entity Framework, Azure SDKs, and Azure Identity.


---

### 05-collections

Topics:

- Array
- List<T>
- Dictionary<TKey, TValue>
- HashSet<T>
- Queue<T>
- Stack<T>
- Collection Initialization
- Iteration
- Sorting
- IReadOnlyList<T>

Key Takeaways:

- `List<T>` is the default general-purpose dynamic collection.
- `Dictionary<TKey,TValue>` provides fast key-based lookup.
- `HashSet<T>` guarantees uniqueness and supports set operations.
- `Queue<T>` provides FIFO behavior.
- `Stack<T>` provides LIFO behavior.
- `IReadOnlyList<T>` is useful for exposing read-only collection access.
- Collections are the foundation for LINQ.

---

### 06 - LINQ

#### Learning Objectives

Understand Language Integrated Query (LINQ) and how it enables expressive collection processing.

Topics:

- Where
- Select
- OrderBy
- First
- Any
- All
- GroupBy
- ToDictionary
- SelectMany
- Query Syntax
- Deferred Execution

#### Key Takeaways

- LINQ provides declarative collection processing.
- Where filters data.
- Select transforms data.
- GroupBy groups data.
- SelectMany flattens nested collections.
- LINQ uses deferred execution by default.
- Most modern .NET applications rely heavily on LINQ.

---

### 07-records

Topics:

- Positional Records
- Record Classes
- Record Structs
- Value Equality
- `with` Expressions
- Immutable Object Updates
- Nested Records
- Records as DTOs
- Pattern Matching with Records

Key Takeaways:

- Records are designed for data-centric types.
- Records provide value equality by default.
- Records reduce boilerplate for DTOs and value objects.
- `with` expressions create non-mutating copies.
- `with` expressions perform shallow copies, not deep copies.
- Record classes are reference types.
- Record structs are value types.
- Records are useful for API responses, configuration models, and immutable data.
- Records pair naturally with pattern matching.

---

### 08-exceptions

Topics:

- try / catch / finally
- throw
- rethrow with `throw;`
- built-in exceptions
- custom exceptions
- exception filters
- validation exceptions
- TryParse pattern
- async exceptions

Key Takeaways:

- Exceptions represent exceptional failures.
- Catch specific exceptions before general exceptions.
- `finally` is used for cleanup.
- Use `throw;` to preserve stack trace.
- Avoid `throw ex;`.
- Custom exceptions are useful for domain-specific failures.
- Exception filters allow conditional catch logic.
- Do not use exceptions for normal control flow.
- Prefer `TryParse` and `TryGetValue` for expected failures.
- Async exceptions are caught around `await`.
- C# does not have checked exceptions like Java.

---

### 09-delegates-and-events

Topics:

- delegate
- Func
- Action
- Predicate
- Lambda Expressions
- Callbacks
- Events
- EventHandler<T>
- Multicast Delegates
- LINQ Delegate Usage

Key Takeaways:

- A delegate is a type-safe reference to a method.
- `Func<T>` represents a method that returns a value.
- `Action<T>` represents a method that returns void.
- `Predicate<T>` represents a method returning bool.
- Lambdas are concise inline delegate implementations.
- Delegates allow behavior to be passed as data.
- Events are built on top of delegates.
- `EventHandler<TEventArgs>` is the standard .NET event pattern.
- Delegates can be multicast.
- LINQ methods rely heavily on delegates.

---

### 10-async-await

Topics:

- Task
- Task<T>
- async
- await
- Dependent vs Independent Tasks
- Fan-Out / Fan-In Pattern
- Task.WhenAll
- Task.WhenAny
- CancellationToken
- Async Exceptions
- IAsyncEnumerable<T>
- Identity Token Async Scenarios

Key Takeaways:

- `Task` represents future work.
- `Task<T>` represents future work that returns a value.
- `await` waits without blocking a thread.
- If task B depends on task A's result, use sequential awaits.
- If task B does not depend on task A's result, start both tasks first and use `Task.WhenAll`.
- After `Task.WhenAll`, awaiting individual tasks retrieves results; it does not run them again.
- Fan-Out / Fan-In is useful for partial dependency graphs.
- `CancellationToken` enables cooperative cancellation.
- Async exceptions are caught around `await`.
- Avoid `.Result` and `.Wait()`.
- Async/await is essential for ASP.NET Core, Azure SDKs, and Identity systems.

---

## Notes

```text
notes
├── architecture
├── fundamentals
├── dotnet
├── aspnet-core
└── azure-identity
```

---

## Environment

* macOS
* .NET 8
* VS Code
* C# Dev Kit
* GitHub


## Phase 2 - ASP.NET Core

Focus:

* Web APIs
* Routing
* Controllers
* Dependency Injection
* Middleware
* Configuration
* Logging
* Error Handling

Projects:

| Status | Project                      | Topics                                                       |
| ------ | ---------------------------- | ------------------------------------------------------------ |
| ✅      | 01-minimal-api               | WebApplication, Routing, MapGet, MapPost, JSON Serialization |
| ✅      | 02-controller-api            | Controller, Action, Routing, ApiController, IActionResult    |
| ✅      | 03-dependency-injection      | Service Lifetimes, Interfaces, IoC Container                 |
| ✅      | 04-options-pattern           | IOptions, Configuration Binding                              |
| ✅      | 05-middleware                | Request Pipeline, Custom Middleware                          |
| ✅      | 06-logging                   | ILogger, Structured Logging                                  |
| ✅      | 07-configuration             | appsettings.json, Environment Variables                      |
| ✅      | 08-global-exception-handling | Exception Handling, ProblemDetails                           |
| ✅      | 09-api-versioning            | API Versioning Strategies                                    |
| ✅      | 10-health-checks             | Health Checks, Readiness, Liveness                           |


## ASP.NET Core Architecture Map

```text
Program.cs
│
├── Service Registration
│       ├── AddControllers()
│       ├── AddScoped()
│       ├── AddSingleton()
│       ├── AddTransient()
│       ├── AddOptions()
│       └── AddHealthChecks()
│
├── Middleware Pipeline
│       ├── Logging
│       ├── Exception Handling
│       ├── Configuration
│       └── Routing
│
└── Endpoint Registration
        ├── MapGet()
        ├── MapPost()
        ├── MapDelete()
        ├── MapControllers()
        └── MapHealthChecks()

Request
    ↓
Middleware Pipeline
    ↓
Endpoint Selection
    ↓
Controller / Minimal API / Health Check
    ↓
Service
    ↓
Response
```

Cross-Cutting Concerns:

* Dependency Injection
* Configuration
* Logging
* Exception Handling
* API Versioning
* Health Checks


### Completed Knowledge

#### Project 01 - Minimal API

Key concepts:

* WebApplicationBuilder
* Dependency Injection (basic)
* MapGet
* MapPost
* JSON Model Binding
* Results.Ok
* Results.Created

Mental Model:

```text
HTTP Request
    ↓
Endpoint
    ↓
Service
    ↓
JSON Response
```

---

#### Project 02 - Controller API

Key concepts:

* Controller
* ControllerBase
* ApiController
* Route
* HttpGet
* HttpPost
* IActionResult
* Constructor Injection

Mental Model:

```text
HTTP Request
    ↓
Routing
    ↓
Controller
    ↓
Action
    ↓
Service
    ↓
HTTP Response
```

---

#### Project 03 - Dependency Injection

Core Concepts:

* Dependency Injection (DI)
* Inversion of Control (IoC)
* Interface vs Implementation
* Constructor Injection
* Service Registration
* Service Lifetimes

Key APIs:

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

```csharp
public UsersController(IUserService userService)
{
    _userService = userService;
}
```

Important Knowledge:

* Controllers should depend on abstractions, not concrete implementations.
* ASP.NET Core uses a built-in DI Container.
* Dependencies are injected through constructors.
* Services are registered in Program.cs.
* Interfaces improve maintainability and testability.

Service Lifetimes:

| Lifetime  | Meaning                             |
| --------- | ----------------------------------- |
| Singleton | One instance for entire application |
| Scoped    | One instance per HTTP request       |
| Transient | New instance every injection        |

Mental Model:

```text
Controller
    ↓
IUserService
    ↓
UserService
    ↓
Response
```

Takeaway:

```text
Do not create dependencies with new.
Declare dependencies and let ASP.NET Core inject them.
```

---

#### Project 04 - Options Pattern

Core Concepts:

* Configuration Management
* appsettings.json
* Strongly Typed Configuration
* Options Pattern
* IOptions<T>

Key APIs:

```csharp
builder.Services.Configure<UserSettingsOptions>(
    builder.Configuration.GetSection(
        UserSettingsOptions.SectionName));
```

```csharp
public UserService(
    IOptions<UserSettingsOptions> options)
{
    _settings = options.Value;
}
```

Important Knowledge:

* Configuration should not be hardcoded.
* appsettings.json stores application settings.
* Options classes represent configuration sections.
* ASP.NET Core automatically binds configuration to objects.
* Configuration can be injected through DI.

Configuration Flow:

```text
appsettings.json
    ↓
GetSection(...)
    ↓
UserSettingsOptions
    ↓
IOptions<UserSettingsOptions>
    ↓
UserService
```

Key Files:

```text
appsettings.json
Options/UserSettingsOptions.cs
Program.cs
```

Takeaway:

```text
Use strongly typed configuration instead of raw string lookups.
```

---

#### Project 05 - Middleware

Core Concepts:
* Middleware
* Request Pipeline
* HttpContext
* RequestDelegate
* Short Circuiting

Key APIs:
```csharpt
app.UseRequestLogging();
await _next(context);
```

Middleware Flow:
```
Request
    ↓
Middleware
    ↓
Controller
    ↓
Response
    ↑
Middleware
```

RequestDelegate:
```csharp
public delegate Task RequestDelegate(
    HttpContext context);
```

Pipeline Example:
```
Request
    ↓
Logging Middleware
    ↓
Controller
    ↓
Response
```

✅ Takeaway: Middleware wraps Controllers and forms the backbone of the ASP.NET Core request pipeline.

---

#### Project 06 - Logging

Learned:
* ILogger
* Log Levels
* Structured Logging
* Correlation ID
* BeginScope()

Mental Model:
```
Request
    ↓
Middleware Logging
    ↓
Controller Logging
    ↓
Service Logging
    ↓
Response
```

---

#### Project 07 - Configuration

Learned:
* IConfiguration
* appsettings.json
* appsettings.{Environment}.json
* Environment Variables
* Configuration Provider Precedence

Mental Model:
```
Configuration Providers
    ↓
IConfiguration
    ↓
Options Binding
    ↓
IOptions<T>
    ↓
Services
```

Deep-Dive Topics:
* IWebHostEnvironment
* Configuration Providers
* Provider Precedence
* Environment-Based Configuration

---

#### Project 08 - Global Exception Handling

Learned:
* Global Exception Handling
* Exception Middleware
* Custom Application Exceptions
* Error Response Contracts
* HTTP Status Mapping
* Expected vs Unexpected Exceptions
* TraceId and Diagnostics

Mental Model:
```
Request
    ↓
Exception Middleware
    ↓
Controller
    ↓
Service
    ↓
Exception
    ↑
Exception Middleware
    ↓
JSON Error Response
```

Deep-Dive Topics:
* Middleware Pipeline Internals
* RequestDelegate Chain
* Exception Propagation
* Error Contract Design
* TraceIdentifier
* Production Error Handling
* Logging + Exception Correlation

Key Takeaways:
1. Controllers should not contain repeated try/catch blocks.
2. Business logic should throw domain/application exceptions.
3. Middleware should translate exceptions into HTTP responses.
4. Expected exceptions map to 4xx responses.
5. Unexpected exceptions map to 500 responses.
6. Internal exception details should not be exposed to clients.
7. TraceId is critical for production debugging.
8. Exception handling is a cross-cutting concern and belongs in middleware.

---

#### Project 09 api-versioning

##### Goal

Learn how to evolve API contracts without breaking existing clients.

---

##### Topics

* API Contracts
* Breaking Changes
* URL Versioning
* DTO Versioning
* Controller Versioning
* Contract Evolution

---

##### Core Idea

An API is a contract between a server and its clients.

Once clients depend on a contract, changing it can break them.

Versioning allows old and new contracts to coexist.

```text
/api/v1/users
/api/v2/users
```

---

##### Breaking Changes

Examples:

* Renaming fields
* Removing fields
* Changing routes
* Changing response schemas
* Adding required request fields

Example:

V1:

```json
{
  "id": 1,
  "name": "Alice"
}
```

V2:

```json
{
  "id": 1,
  "displayName": "Alice",
  "email": "alice@example.com",
  "isActive": true
}
```

Changing `name` → `displayName` is a breaking change.

---

##### Design Principles

###### Separate DTOs

```text
Contracts/V1/
Contracts/V2/
```

Different API versions should have independent request/response contracts.

###### Separate Controllers

```text
Controllers/V1/
Controllers/V2/
```

Different versions often evolve independently.

###### Shared Domain Model

```text
Domain Model
    ↓
V1 Contract

Domain Model
    ↓
V2 Contract
```

Internal models can remain stable while API contracts evolve.

---

### Key Takeaways

1. APIs are contracts.
2. Breaking changes require versioning.
3. Multiple API versions can coexist.
4. Domain models and API contracts should be separated.
5. Different versions should have separate DTOs.
6. Different versions often benefit from separate Controllers.
7. Versioning enables gradual client migration.

---

#### Project 10 Health Checks

##### Goal

Learn how production systems determine whether an application is alive and ready to receive traffic.

---

##### Topics

* Health Checks
* Liveness
* Readiness
* IHealthCheck
* HealthCheckResult
* Production Monitoring
* Kubernetes Probes

---

##### Core Idea

Health Checks answer two questions:

```text
Is the application alive?

Can the application serve traffic?
```

ASP.NET Core exposes dedicated endpoints for this purpose.

---

### Liveness

Question:

```text
Is the application process running?
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

##### Readiness

Question:

```text
Can this application instance currently receive traffic?
```

Endpoint:

```text
/health/ready
```

If readiness fails:

```text
Platform removes the instance from traffic.
```

---

##### Health States

ASP.NET Core supports:

```text
Healthy
Degraded
Unhealthy
```

Healthy:

* Everything works.

Degraded:

* Application still functions, but some dependencies are impaired.

Unhealthy:

* Application cannot correctly serve requests.

---

##### Custom Health Checks

Custom checks implement:

```csharp
IHealthCheck
```

Examples:

```text
DatabaseHealthCheck
RedisHealthCheck
ServiceBusHealthCheck
ExternalApiHealthCheck
```

---

##### Production Guidance

Dependencies generally belong in Readiness checks:

```text
Database
Redis
Message Queue
External API
```

Avoid placing dependency checks in Liveness probes.

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

##### Key Takeaways

1. Health Checks are production endpoints.
2. Liveness and Readiness serve different purposes.
3. Dependencies usually belong in Readiness checks.
4. Custom checks implement IHealthCheck.
5. ASP.NET Core supports Healthy, Degraded, and Unhealthy states.
6. Health Checks are essential for Kubernetes and cloud-native systems.
7. Health Checks improve application operability and reliability.


---

## Appendix
* Override 用于重写父类已经实现的方法。
* Implement 是实现 interface 中定义的抽象方法。