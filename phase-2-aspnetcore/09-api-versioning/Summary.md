# Project 09 Summary - API Versioning

## Core Idea

API versioning lets an application support multiple API contracts at the same time.

This prevents breaking old clients when new API behavior is introduced.

## Why Version APIs?

APIs are contracts between server and client.

Changing a contract can break clients.

Examples of breaking changes:

- renaming a response field
- removing a field
- changing data type
- changing route shape
- changing required request body fields
- changing status code behavior

Versioning allows:

```text
Old clients -> v1
New clients -> v2
```

## URL-Based Versioning

This project uses URL-based versioning:

```text
/api/v1/users
/api/v2/users
```

## V1 Contract

V1 response:

```json
{
  "id": 1,
  "name": "Alice"
}
```

V1 create request:

```json
{
  "name": "Diana"
}
```

## V2 Contract

V2 response:

```json
{
  "id": 1,
  "displayName": "Alice",
  "email": "alice@example.com",
  "isActive": true
}
```

V2 create request:

```json
{
  "displayName": "Eve",
  "email": "eve@example.com"
}
```

## Shared Domain Model

Both v1 and v2 use the same internal domain model:

```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
```

The domain model can be stable while API contracts evolve.

## Separate Contracts

This project uses separate DTOs:

```text
Contracts/V1/UserResponse.cs
Contracts/V2/UserResponse.cs
```

This prevents accidental breaking changes.

## Separate Controllers

This project uses separate controllers:

```text
Controllers/V1/UsersController.cs
Controllers/V2/UsersController.cs
```

This makes differences between versions explicit.

## Key Takeaways

1. APIs are contracts.
2. Changing contracts can break clients.
3. Versioning lets old and new contracts coexist.
4. URL versioning is simple and explicit.
5. V1 and V2 can share domain models but should have separate DTOs.
6. Separate controllers make version differences clear.
