# 03 - OOP

## Learning Objectives

Understand modern C# object-oriented programming and compare it with Java.

Topics:

* Class
* Constructor
* Property
* Inheritance
* Interface
* Abstract Class
* Virtual / Override
* Sealed
* Record
* Init-only Property

---

# Project Structure

```text
03-oop
├── Program.cs
├── Models
├── Interfaces
├── Abstracts
└── Examples
```

Design principle:

* Program.cs = entry point
* Models = domain objects
* Interfaces = contracts
* Abstracts = shared behavior
* Examples = demonstrations

---

# Class

```csharp
public class Person
{
    public required string Name { get; init; }

    public int Age { get; init; }
}
```

Compared with Java:

```java
private String name;
private int age;

public String getName() {}
public void setName() {}
```

C# Property eliminates most boilerplate.

---

# Constructor

```csharp
public BankAccount(
    string accountId,
    string ownerName)
{
    AccountId = accountId;
    OwnerName = ownerName;
}
```

Equivalent to Java constructors.

---

# Inheritance

```csharp
public class Employee : Person
{
}
```

C# uses:

```csharp
:
```

for both inheritance and interface implementation.

---

# Interface

```csharp
public interface IWorker
{
    void Work();
}
```

Convention:

```text
IWorker
ILogger
IDisposable
IEnumerable
```

All .NET interfaces start with "I".

---

# Abstract Class

```csharp
public abstract class WorkerBase
{
    public abstract void Work();
}
```

Purpose:

* Shared implementation
* Force subclasses to implement behavior

---

# Virtual and Override

Base class:

```csharp
public virtual string GetRole()
{
    return "Employee";
}
```

Derived class:

```csharp
public override string GetRole()
{
    return "Manager";
}
```

Important difference from Java:

Java methods are virtually overridable by default.

C# requires explicit:

```csharp
virtual
override
```

---

# Sealed

```csharp
public sealed class Manager
{
}
```

Equivalent to Java:

```java
final class Manager
{
}
```

Prevents inheritance.

---

# Record

```csharp
public record Address(
    string City,
    string State);
```

Automatically provides:

* Constructor
* Equals
* GetHashCode
* ToString
* Immutable semantics

Example:

```csharp
var address2 = address1 with
{
    City = "Bellevue"
};
```

This is one of the most important modern C# features.

---

# Init-only Properties

```csharp
public string Name { get; init; }
```

Allowed:

```csharp
var user = new User
{
    Name = "Alex"
};
```

Not allowed:

```csharp
user.Name = "Bob";
```

Provides immutability after construction.

---

# Java vs C#

| Java                | C#               |
| ------------------- | ---------------- |
| Getter/Setter       | Property         |
| extends             | :                |
| implements          | :                |
| final class         | sealed           |
| record              | record           |
| override by default | explicit virtual |
| immutable builder   | init             |

---

# Key Takeaways

Most valuable concepts:

1. Property
2. Record
3. Init-only Property
4. Virtual / Override

These appear frequently in:

* ASP.NET Core
* Azure SDK
* Azure Identity
* Microsoft internal services
