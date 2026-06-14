# 04 - Generics

## Learning Objectives

Understand how generics enable reusable and type-safe code.

---

## What is a Generic?

A Generic is a type-safe template that allows code to work with many different types.

Instead of writing:

```csharp
UserRepository

ProductRepository

TokenRepository
```

we write:

```csharp
Repository<T>
```

and let the compiler substitute the actual type.

---

## Why Generics?

Without generics:

```csharp
ArrayList list = new();

list.Add("Alex");
list.Add(123);
```

Problems:

* No compile-time type safety
* Runtime casting
* Runtime errors

With generics:

```csharp
List<string> names = new();
```

The compiler guarantees that only strings can be added.

---

## Project Structure

```text
04-generics
├── Models
├── Interfaces
├── Repositories
├── Examples
├── Program.cs
└── README.md
```

---

## Topics

### Generic Collections

```csharp
List<T>

Dictionary<TKey, TValue>

HashSet<T>
```

---

### Generic Methods

```csharp
PrintValue<T>()
```

---

### Generic Classes

```csharp
ApiResponse<T>
```

---

### Generic Interfaces

```csharp
IRepository<T>
```

---

### Generic Repository

```csharp
InMemoryRepository<T>
```

---

### Generic Constraints

```csharp
where T : IEntity

where T : class

where T : new()
```

---

## Java vs C#

| Java         | C#                      |
| ------------ | ----------------------- |
| List<T>      | List<T>                 |
| Map<K,V>     | Dictionary<TKey,TValue> |
| T extends X  | where T : X             |
| Type Erasure | Reified Generics        |
| No new T()   | where T : new()         |

---

## Key Takeaways

1. Generics provide compile-time type safety.
2. Generics eliminate duplicate implementations.
3. Generic constraints restrict allowable types.
4. Repository patterns heavily rely on generics.
5. Generics are foundational to LINQ, DI, ASP.NET Core, and Azure Identity.

---

## Next Step

05-collections
