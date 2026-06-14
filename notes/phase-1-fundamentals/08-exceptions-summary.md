# 08 - Exceptions Summary

## What is an Exception?

An exception represents an unexpected or exceptional failure.

Examples:

- Divide by zero
- Null reference
- Invalid argument
- Missing user
- Authentication failure
- Network failure

```csharp
throw new InvalidOperationException("Something went wrong.");
```

---

## try / catch

```csharp
try
{
    DoSomething();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

`try` contains code that may fail. `catch` handles the failure.

---

## Catch Specific Exceptions First

```csharp
catch (NullReferenceException ex)
{
}
catch (Exception ex)
{
}
```

Specific exceptions should come before general exceptions.

---

## finally

```csharp
finally
{
    Console.WriteLine("Cleanup");
}
```

`finally` runs whether an exception occurs or not.

Use it for cleanup.

---

## throw

```csharp
throw new ArgumentException("Name cannot be empty.", nameof(name));
```

Common exceptions:

- `ArgumentException`
- `ArgumentNullException`
- `InvalidOperationException`
- `NotSupportedException`
- `UnauthorizedAccessException`

---

## Rethrow

Correct:

```csharp
throw;
```

Avoid:

```csharp
throw ex;
```

`throw;` preserves the original stack trace.

---

## Custom Exceptions

```csharp
public class UserNotFoundException : Exception
{
    public string UserId { get; }

    public UserNotFoundException(string userId)
        : base($"User '{userId}' was not found.")
    {
        UserId = userId;
    }
}
```

Use custom exceptions for domain-specific failures.

---

## Exception Filters

```csharp
catch (AuthenticationFailedException ex) when (ex.ClientId == "client-001")
{
}
```

`when` adds conditional catch logic.

---

## TryParse Pattern

```csharp
if (int.TryParse(input, out var number))
{
}
```

Use `TryParse` for expected failures.

Do not use exceptions for normal control flow.

---

## Async Exceptions

```csharp
try
{
    var result = await service.CallAsync();
}
catch (Exception ex)
{
}
```

Async exceptions are rethrown when the task is awaited.

---

## Java vs C#

| Java | C# |
|---|---|
| checked exceptions | no checked exceptions |
| throws declaration | no throws declaration |
| try-with-resources | using / await using |
| Optional parsing | TryParse pattern |

---

## Key Takeaways

1. Exceptions represent exceptional failures.
2. Catch specific exceptions first.
3. Use `finally` for cleanup.
4. Use `throw;` to preserve stack trace.
5. Avoid `throw ex;`.
6. Use custom exceptions for domain-specific errors.
7. Use exception filters for conditional handling.
8. Prefer `TryParse` / `TryGetValue` for expected failures.
9. Async exceptions are caught around `await`.
10. C# does not have checked exceptions.
11. Do not swallow exceptions silently.
12. Catch exceptions at meaningful boundaries.
