# Solutions

## Exercise 01

```csharp
public static bool IsPresent(this string? value)
{
    return !string.IsNullOrWhiteSpace(value);
}

public static string OrDefault(this string? value, string fallback)
{
    return string.IsNullOrWhiteSpace(value) ? fallback : value;
}
```

## Exercise 02

```csharp
public static bool IsEmailLike(this string? value)
{
    if (string.IsNullOrWhiteSpace(value)) return false;

    string[] parts = value.Split('@');
    if (parts.Length != 2) return false;

    string local = parts[0];
    string domain = parts[1];

    return local.Length > 0 && domain.Contains('.') && !domain.StartsWith('.') && !domain.EndsWith('.');
}
```

## Exercise 03

```csharp
public static string TrimAndCollapseSpaces(this string value)
{
    string[] parts = value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    return string.Join(' ', parts);
}
```

## Exercise 04

```csharp
public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
{
    return condition ? source.Where(predicate) : source;
}
```
