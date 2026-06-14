# Exercise 04 - Enumerable Extensions

Create an extension method:

```csharp
public static IEnumerable<T> WhereIf<T>(
    this IEnumerable<T> source,
    bool condition,
    Func<T, bool> predicate)
```

When `condition` is true, apply `Where(predicate)`.
When false, return the original source.
