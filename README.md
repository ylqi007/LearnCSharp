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
* Dependency Injection
* Middleware
* Configuration
* Logging
* Error Handling

Projects:
* 01-minimal-api
* 02-controller-api
* 03-dependency-injection
* 04-options-pattern
* 05-middleware
* 06-logging
* 07-configuration
* 08-global-exception-handling
* 09-api-versioning
* 10-health-checks

Key Outcome:
* Build REST APIs using ASP.NET Core
* Understand the ASP.NET Core request pipeline
* Understand Dependency Injection