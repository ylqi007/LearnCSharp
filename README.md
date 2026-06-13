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
| ⏳      | 06-linq                  |
| ⏳      | 07-records               |
| ⏳      | 08-exceptions            |
| ⏳      | 09-delegates-and-events  |
| ⏳      | 10-async-await           |

Current Focus:

04-generics

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
