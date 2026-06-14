# 03 - OOP

This project focuses on C# object-oriented programming concepts, especially the differences between Java OOP and modern C# OOP.

## Topics

- class
- constructor
- property
- inheritance
- interface
- abstract class
- virtual / override
- sealed
- record
- init-only property

## UML Class Diagram

```mermaid
classDiagram
    direction LR

    class Person {
        +string Name
        +int Age
        +GetDescription() string
    }

    class Employee {
        +string EmployeeId
        +string Department
        +GetRole() string
        +Work() void
        +GetDescription() string
    }

    class Manager {
        +int TeamSize
        +GetRole() string
        +Manage() void
        +GetDescription() string
    }

    class IWorker {
        <<interface>>
        +Work() void
    }

    class IManager {
        <<interface>>
        +Manage() void
    }

    class Address {
        <<record>>
        +string Street
        +string City
        +string State
        +string ZipCode
    }

    class UserProfile {
        +string UserId
        +string DisplayName
        +Address? Address
    }

    class WorkerBase {
        <<abstract>>
        +string Name
        +Work() void
        +PrintName() void
    }

    class SoftwareEngineer {
        -nested class
        +string PrimaryLanguage
        +Work() void
    }

    class BankAccount {
        -nested class
        +string AccountId
        +string OwnerName
        +BankAccount(accountId, ownerName)
        +GetSummary() string
    }

    Person <|-- Employee
    Employee <|-- Manager

    IWorker <|.. Employee
    IManager <|.. Manager

    UserProfile o-- Address : has optional

    WorkerBase <|-- SoftwareEngineer
```

## Run

```bash
dotnet run
```

## Key Java vs C# Differences

| Java | C# |
|---|---|
| Getter / Setter | Property |
| `extends` | `:` |
| `implements` | `:` |
| `final` class | `sealed` class |
| Java record | C# record |
| Override by default? | Must explicitly use `virtual` |
| `@Override` | `override` |
| Immutable init pattern | `init` |


## Key Takeaways:
* Properties replace much of the boilerplate getter/setter code common in Java.
* Interfaces convertially start with `I` in .NET.
* `virtual` and `override` must be explicitly declared.
* `sealed` is the C# equivalant of Java's `final` class.
* Records provide concise immutable data models with build-in value equality.
* `init` enables immutable object initialization patterns.
