# 06 - LINQ Summary

## Learning Objectives

LINQ stands for **Language Integrated Query**. It allows developers to query and transform collections using expressive, type-safe operations.

## Why LINQ Matters

LINQ is everywhere in modern .NET: ASP.NET Core, Azure SDKs, Entity Framework, configuration, logging, identity and token processing, filtering, aggregation, and API response shaping.

Without LINQ:

```csharp
List<string> names = new();

foreach (var user in users)
{
    if (user.Salary >= 160000)
    {
        names.Add(user.Name);
    }
}
```

With LINQ:

```csharp
var names = users
    .Where(user => user.Salary >= 160000)
    .Select(user => user.Name);
```

LINQ makes code more declarative, readable, composable, and expressive.

## IEnumerable<T>

Most LINQ methods operate on `IEnumerable<T>`. Most collections implement it, including `List<T>`, `HashSet<T>`, `Queue<T>`, `Stack<T>`, and `Dictionary<TKey,TValue>`.

## Where

Filters data.

```csharp
var highSalaryUsers = users
    .Where(user => user.Salary >= 160000);
```

Java equivalent: `filter()`.

## Select

Transforms data.

```csharp
var names = users
    .Select(user => user.Name);
```

Transforms `User` into `string`. Java equivalent: `map()`.

## OrderBy and ThenBy

Sorts data.

```csharp
var ordered = users
    .OrderBy(user => user.Department)
    .ThenByDescending(user => user.Salary);
```

`OrderBy` starts sorting. `ThenBy` adds secondary sorting.

## First and FirstOrDefault

`First` returns the first match and throws if no match exists.

```csharp
var user = users.First(user => user.Salary >= 160000);
```

`FirstOrDefault` returns default value if no match exists.

```csharp
var user = users.FirstOrDefault(user => user.Id == "u999");
```

For reference types, default is `null`.

## Single and SingleOrDefault

`Single` requires exactly one match.

```csharp
var user = users.Single(user => user.Id == "u001");
```

It throws if zero or more than one match exists. Use `Single` when uniqueness is a business rule.

## Any, All, Count

`Any` checks whether at least one element matches.

```csharp
users.Any(user => user.Salary >= 200000);
```

`All` checks whether all elements match.

```csharp
users.All(user => !string.IsNullOrWhiteSpace(user.Department));
```

`Count(predicate)` counts matching elements.

Prefer `Any()` over `Count() > 0` when only checking existence.

## GroupBy

Groups data by key.

```csharp
var usersByDepartment = users
    .GroupBy(user => user.Department);
```

Each group has `group.Key` and the grouped items.

Aggregation example:

```csharp
var averageSalaryByDepartment = users
    .GroupBy(user => user.Department)
    .Select(group => new
    {
        Department = group.Key,
        AverageSalary = group.Average(user => user.Salary)
    });
```

## ToDictionary

Creates key-based lookup.

```csharp
var usersById = users
    .ToDictionary(user => user.Id);
```

Warning: `ToDictionary` throws if duplicate keys exist.

## SelectMany

Flattens nested collections.

```csharp
var allProductIds = orders
    .SelectMany(order => order.ProductIds);
```

Transforms `IEnumerable<IEnumerable<T>>` into `IEnumerable<T>`. Java equivalent: `flatMap()`.

## Distinct

Removes duplicates.

```csharp
var uniqueProductIds = orders
    .SelectMany(order => order.ProductIds)
    .Distinct();
```

## Query Syntax vs Method Syntax

Query syntax:

```csharp
var query =
    from user in users
    where user.Salary >= 160000
    orderby user.Name
    select user;
```

Method syntax:

```csharp
var query = users
    .Where(user => user.Salary >= 160000)
    .OrderBy(user => user.Name)
    .Select(user => user);
```

Method syntax is more common in production .NET code.

## Deferred Execution

LINQ queries are usually deferred.

```csharp
var query = users.Where(user => user.Salary >= 160000);
```

The query has not executed yet. It runs when enumerated by `foreach` or materialized with `ToList()`, `Count()`, `First()`, etc.

Use `ToList()` when you need immediate execution or stable results.

## Java Stream API vs C# LINQ

| Java Stream | C# LINQ |
|---|---|
| filter | Where |
| map | Select |
| flatMap | SelectMany |
| sorted | OrderBy |
| anyMatch | Any |
| allMatch | All |
| count | Count |
| collect(toList()) | ToList |
| collect(toMap()) | ToDictionary |
| groupingBy | GroupBy |
| findFirst | FirstOrDefault |

## Common Mistakes

1. Using `Count() > 0` instead of `Any()`.
2. Using `First()` when the item may not exist.
3. Forgetting deferred execution.
4. Using `ToDictionary()` with duplicate keys.
5. Re-enumerating expensive queries multiple times.

## Most Important Takeaways

1. LINQ provides declarative collection processing.
2. `Where` filters.
3. `Select` transforms.
4. `OrderBy` sorts.
5. `FirstOrDefault` is safer when missing data is possible.
6. `Single` enforces uniqueness.
7. `Any` checks existence.
8. `All` validates all elements.
9. `GroupBy` groups and aggregates.
10. `ToDictionary` creates lookup maps.
11. `SelectMany` flattens nested collections.
12. LINQ uses deferred execution.
13. `ToList()` materializes a query.
14. Method syntax is more common than query syntax.
15. LINQ is foundational for ASP.NET Core, EF Core, Azure SDK, and Azure Identity.

## Next Step

```text
07-records
```
