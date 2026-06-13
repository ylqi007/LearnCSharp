# 06 - LINQ

## Learning Objectives

Understand LINQ (Language Integrated Query) and how it enables expressive, type-safe collection processing in C#.

## Topics

- `Where`
- `Select`
- `OrderBy` / `ThenBy`
- `First` / `FirstOrDefault`
- `Single` / `SingleOrDefault`
- `Any` / `All` / `Count`
- `GroupBy`
- `ToDictionary`
- `SelectMany`
- Query Syntax
- Deferred Execution

## Why LINQ Matters

LINQ is one of the most important features in modern C#.

It is heavily used in ASP.NET Core, Azure SDKs, Entity Framework, configuration, logging, identity systems, data transformation, filtering, and aggregation.

If collections are the data containers, LINQ is the expressive language used to query and transform them.

## Project Structure

```text
06-linq
├── Program.cs
├── Models
│   ├── User.cs
│   ├── Product.cs
│   └── Order.cs
│
└── Examples
    ├── SampleData.cs
    ├── WhereExamples.cs
    ├── SelectExamples.cs
    ├── OrderByExamples.cs
    ├── FirstExamples.cs
    ├── AnyAllExamples.cs
    ├── GroupByExamples.cs
    ├── ToDictionaryExamples.cs
    ├── SelectManyExamples.cs
    ├── QuerySyntaxExamples.cs
    └── DeferredExecutionExamples.cs
```

## Run

```bash
dotnet run
```

## Method Syntax

Most production C# code uses method syntax:

```csharp
var result = users
    .Where(user => user.Salary > 160000)
    .OrderBy(user => user.Name)
    .Select(user => user.Name);
```

## Query Syntax

C# also supports SQL-like query syntax:

```csharp
var result =
    from user in users
    where user.Salary > 160000
    orderby user.Name
    select user.Name;
```

Method syntax is more common in modern .NET code.

## Java Comparison

| Java Stream | C# LINQ |
|---|---|
| filter | Where |
| map | Select |
| flatMap | SelectMany |
| sorted | OrderBy |
| anyMatch | Any |
| allMatch | All |
| collect(toList()) | ToList |
| collect(toMap()) | ToDictionary |
| groupingBy | GroupBy |

## Key Takeaways

1. `Where` filters data.
2. `Select` transforms data.
3. `OrderBy` sorts data.
4. `FirstOrDefault` safely returns one optional result.
5. `Single` should be used only when exactly one result is expected.
6. `Any` checks existence.
7. `All` checks whether all elements satisfy a condition.
8. `GroupBy` groups data by key.
9. `ToDictionary` creates fast key-based lookup.
10. `SelectMany` flattens nested collections.
11. LINQ uses deferred execution by default.
12. `ToList()` materializes a query immediately.

## Next Step

```text
07-records
```
