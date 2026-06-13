# 07 - Records Summary

## Learning Objectives

This project focuses on C# records.

Records are modern C# types designed for:

- Immutable data
- Value equality
- DTOs
- Value objects
- Concise data modeling
- Safe object copying

---

# What is a Record?

A record is a type that is optimized for storing data.

Example:

```csharp
public record UserRecord(
    string Id,
    string Name,
    string? Email);
```

This single declaration automatically provides:

- Constructor
- Properties
- `ToString()`
- `Equals()`
- `GetHashCode()`
- Deconstruction support
- Value equality

---

# Why Records Matter

Before records, developers often wrote classes like this:

```csharp
public class User
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string? Email { get; init; }
}
```

Then they had to manually implement:

- Equality
- Hash code
- ToString
- Copying

Records remove most of that boilerplate.

---

# Positional Records

A positional record is the shortest record syntax:

```csharp
public record UserRecord(
    string Id,
    string Name,
    string? Email);
```

Usage:

```csharp
var user = new UserRecord(
    "u001",
    "Alex",
    "alex@example.com");
```

Generated properties:

```csharp
user.Id
user.Name
user.Email
```

---

# Value Equality

Records compare by value.

```csharp
var user1 = new UserRecord(
    "u001",
    "Alex",
    "alex@example.com");

var user2 = new UserRecord(
    "u001",
    "Alex",
    "alex@example.com");

Console.WriteLine(user1 == user2); // true
```

Classes compare by reference unless equality is overridden.

```csharp
var classUser1 = new UserClass { ... };
var classUser2 = new UserClass { ... };

Console.WriteLine(classUser1.Equals(classUser2)); // false by default
```

## Key Takeaway

Use records when the data identity is based on values.

Use classes when identity is based on object reference or behavior.

---

# With Expressions

Records support non-mutating copy updates.

```csharp
var discounted = product with
{
    Price = 249.99M
};
```

This creates a new record.

The original record is unchanged.

## Why This Matters

This supports immutable programming patterns:

```text
old object
↓
copy with changes
↓
new object
```

This is safer than mutating shared state.

---

# Record Class

Records are reference types by default.

```csharp
public record TokenRecord
{
    public required string TokenType { get; init; }
    public required string AccessToken { get; init; }
    public DateTime ExpiresAt { get; init; }
}
```

This style is useful when:

- You prefer object initializer syntax
- You need required properties
- You do not want a long positional constructor

---

# Record Struct

```csharp
public readonly record struct PointRecordStruct(
    int X,
    int Y);
```

Record structs are value types.

Use them for small data values, such as:

- Coordinates
- Measurements
- Small immutable values

## Record Class vs Record Struct

| Type | Category |
|---|---|
| record class | reference type |
| record struct | value type |

---

# Nested Records

Records work well together.

```csharp
public record AddressRecord(
    string Street,
    string City,
    string State,
    string ZipCode);

public record UserProfileRecord(
    string UserId,
    string DisplayName,
    AddressRecord? Address);
```

Nested update:

```csharp
var movedProfile = profile with
{
    Address = profile.Address with
    {
        City = "Bellevue"
    }
};
```

## Important

If `Address` can be null, use null checks before using `with`.

---

# Records as DTOs

Records are excellent for DTOs.

```csharp
public record ApiResponseRecord<T>(
    bool Success,
    T? Data,
    string? ErrorMessage);
```

Benefits:

- Concise
- Immutable by default
- Easy to log
- Easy to compare in tests
- Easy to serialize

Common in:

- API responses
- Request models
- Configuration objects
- Integration contracts

---

# Pattern Matching with Records

Records work naturally with pattern matching.

```csharp
string label = product switch
{
    { Price: >= 1000 } => "Premium",
    { Price: >= 100 } => "Standard",
    _ => "Budget"
};
```

Pattern matching can inspect properties directly.

```csharp
string emailStatus = user switch
{
    { Email: not null } => "Has email",
    _ => "Missing email"
};
```

---

# Records vs Classes

| Feature | Class | Record |
|---|---|---|
| Main purpose | Behavior / identity | Data / values |
| Equality | Reference equality by default | Value equality by default |
| ToString | Type name by default | Includes property values |
| Copying | Manual | `with` expression |
| DTO suitability | Good | Excellent |
| Mutability | Usually mutable | Usually immutable |

---

# Records vs Java Records

| Java Record | C# Record |
|---|---|
| Data carrier | Data carrier |
| Value equality | Value equality |
| Constructor generated | Constructor generated |
| Immutable fields | init-only style |
| No `with` expression | Supports `with` expression |
| Class-like only | record class and record struct |

---

# When to Use Records

Use records for:

- DTOs
- Value objects
- API contracts
- Configuration models
- Immutable state
- Test expected values
- Data transformation results

Avoid records when:

- Object identity matters
- The type has complex mutable lifecycle
- The object owns resources
- Behavior is more important than data

---

# Real-World Examples

## API Response

```csharp
public record TokenResponse(
    string AccessToken,
    DateTime ExpiresAt);
```

## Configuration

```csharp
public record AuthOptions(
    string Authority,
    string ClientId);
```

## Value Object

```csharp
public record TenantId(string Value);
```

## Projection Result

```csharp
var result = users.Select(user =>
    new UserSummary(
        user.Id,
        user.Name));
```

---

# Common Mistakes

## Mistake 1: Using records for everything

Records are not replacements for all classes.

Use classes for behavior-rich objects.

## Mistake 2: Forgetting records can still hold mutable references

A record can contain a mutable list:

```csharp
public record Order(List<string> ProductIds);
```

The record itself supports value equality, but the list can still be mutated.

## Mistake 3: Assuming `with` performs deep copy

`with` performs a shallow copy.

Nested reference objects are shared unless explicitly copied.

---

# Most Important Takeaways

1. Records are data-focused types.
2. Records provide value equality by default.
3. Records reduce boilerplate.
4. Records are usually used for immutable data.
5. `with` creates a modified copy.
6. `with` is shallow, not deep.
7. Record classes are reference types.
8. Record structs are value types.
9. Records are excellent for DTOs and API contracts.
10. Records work well with pattern matching.

---

# Next Step

```text
08-exceptions
```
