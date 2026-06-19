## 09 API Versioning

### Goal

Learn how to evolve API contracts without breaking existing clients.

---

### Topics

* API Contracts
* Breaking Changes
* URL Versioning
* DTO Versioning
* Controller Versioning
* Contract Evolution

---

### Why Version APIs?

APIs are contracts between servers and clients.

Once clients depend on a contract, changing it can break them.

Examples of breaking changes:

* Renaming fields
* Removing fields
* Changing routes
* Changing request schemas
* Changing response schemas

Versioning allows old and new contracts to coexist.

---

### URL Versioning

Project 09 uses URL-based versioning:

```text
/api/v1/users
/api/v2/users
```

This is the simplest and most explicit versioning strategy.

---

### V1 vs V2

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

---

### Key Design Principles

#### APIs are Contracts

Never assume API contracts can be changed freely.

#### Separate DTOs

```text
Contracts/V1/
Contracts/V2/
```

Different versions should use different request and response contracts.

#### Separate Controllers

```text
Controllers/V1/
Controllers/V2/
```

Different versions often evolve independently.

#### Shared Domain Model

Multiple API versions can share the same internal domain model.

```text
Domain Model
    ↓
V1 Contract

Domain Model
    ↓
V2 Contract
```

---

### Key Takeaways

1. APIs are contracts.
2. Breaking changes require versioning.
3. Multiple API versions can coexist.
4. Domain models and API contracts should be separated.
5. Different versions should have independent DTOs.
6. Different versions often benefit from separate Controllers.
7. Versioning enables gradual client migration.
