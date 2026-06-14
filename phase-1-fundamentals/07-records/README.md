# 07 - Records

## Learning Objectives

Understand C# records and how they support immutable, value-oriented data modeling.

07-records 的核心是：用 C# record 表达“以数据为中心、通常不可变、按值比较”的类型。
* data-first type
* value equality
* less boilerplate
* immutable-friendly

This project covers:

- Positional records
- Record classes
- Record structs
- Value equality
- `with` expressions
- Immutable object updates
- Nested records
- Records as DTOs
- Pattern matching with records

---

## Why Records Matter

Records are one of the most important modern C# features.

They are commonly used for:

- DTOs
- API responses
- Configuration models
- Immutable domain models
- Value objects
- Test data
- Data transformation

Records reduce boilerplate and provide value-based equality by default.

---

## Project Structure

```text
07-records
├── Program.cs
├── Models
│   ├── UserRecord.cs
│   ├── ProductRecord.cs
│   ├── AddressRecord.cs
│   ├── UserProfileRecord.cs
│   ├── ApiResponseRecord.cs
│   ├── TokenRecord.cs
│   ├── PointRecordStruct.cs
│   └── UserClass.cs
│
└── Examples
    ├── BasicRecordExamples.cs
    ├── ValueEqualityExamples.cs
    ├── WithExpressionExamples.cs
    ├── RecordClassExamples.cs
    ├── RecordStructExamples.cs
    ├── NestedRecordExamples.cs
    ├── DtoExamples.cs
    └── PatternMatchingExamples.cs
```

---

## Run

```bash
dotnet run
```

---

## Basic Record

```csharp
public record UserRecord(
    string Id,
    string Name,
    string? Email);
```

This automatically provides:

- Constructor
- Properties
- `ToString()`
- `Equals()`
- `GetHashCode()`
- Value equality

---

## Value Equality

Records compare by value:

```csharp
var user1 = new UserRecord("u001", "Alex", "alex@example.com");
var user2 = new UserRecord("u001", "Alex", "alex@example.com");

Console.WriteLine(user1 == user2); // true
```

Classes compare by reference unless equality is overridden.

---

## With Expression

```csharp
var discounted = product with
{
    Price = 249.99M
};
```

Creates a copy with selected properties changed.

The original record is unchanged.

---

## Record Class

```csharp
public record TokenRecord
{
    public required string TokenType { get; init; }
    public required string AccessToken { get; init; }
}
```

Useful when you prefer object initializer syntax.

---

## Record Struct

```csharp
public readonly record struct PointRecordStruct(
    int X,
    int Y);
```

Useful for small value-like data structures.

---

## Java vs C#

| Java | C# |
|---|---|
| Java record | C# record |
| value equality | value equality |
| compact constructor | positional record |
| immutable DTO | record with init |
| copy manually | `with` expression |

---

## Key Takeaways

1. Records are designed for data-centric types.
2. Records provide value equality by default.
3. Records reduce boilerplate.
4. `with` expressions create non-mutating copies.
5. Records work well for DTOs and API responses.
6. Record classes are reference types.
7. Record structs are value types.
8. Records pair naturally with pattern matching.

---

## Next Step

```text
08-exceptions
```
