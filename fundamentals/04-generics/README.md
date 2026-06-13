# 04 - Generics

This project focuses on C# generics and compares them with Java generics.

## Topics

- Generic methods
- Generic classes
- Generic interfaces
- Generic repositories
- Type constraints
- `where T : class`
- `where T : new()`
- `where T : IEntity`
- `default`
- Type-safe reusable code

## UML Class Diagram

```mermaid
classDiagram
    direction LR

    class IEntity {
        <<interface>>
        +Id string
    }

    class User {
        +Id string
        +Name string
        +Email string?
        +ToString() string
    }

    class Product {
        +Id string
        +Name string
        +Price decimal
        +ToString() string
    }

    class Token {
        +Id string
        +Value string
        +ExpiresAt DateTime
        +IsExpired() bool
        +ToString() string
    }

    class ApiResponse~T~ {
        +Success bool
        +Data T?
        +ErrorMessage string?
        +Ok(data) ApiResponse~T~
        +Fail(errorMessage) ApiResponse~T~
    }

    class IRepository~T~ {
        <<interface>>
        +Add(item) void
        +GetById(id) T?
        +GetAll() IReadOnlyList
    }

    class InMemoryRepository~T~ {
        -items Dictionary
        +Add(item) void
        +GetById(id) T?
        +GetAll() IReadOnlyList
    }

    IEntity <|.. User
    IEntity <|.. Product
    IEntity <|.. Token

    IRepository~T~ <|.. InMemoryRepository~T~

    IRepository~T~ ..> IEntity : T constrained to
    InMemoryRepository~T~ ..> IEntity : T constrained to
```

Notes:

- `ApiResponse<T>` is an unconstrained generic wrapper, so it can wrap any type.
- `IRepository<T>` and `InMemoryRepository<T>` both require `where T : IEntity`.

## Run

```bash
dotnet run
```

## Key Java vs C# Differences

| Java | C# |
|---|---|
| `List<T>` | `List<T>` |
| `Map<K,V>` | `Dictionary<TKey,TValue>` |
| `T extends SomeClass` | `where T : SomeClass` |
| `T extends Interface` | `where T : IInterface` |
| `new T()` not directly allowed | `where T : new()` enables `new T()` |
| Type erasure | Reified generics at runtime |
