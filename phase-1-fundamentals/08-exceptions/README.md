# 08 - Exceptions

## Learning Objectives

Understand exception handling in C# and how to write safe, readable, production-style error handling code.

Topics:

- try / catch / finally
- throw
- rethrow with `throw;`
- custom exceptions
- exception filters
- validation exceptions
- TryParse pattern
- async exceptions

## Run

```bash
dotnet run
```

## Key Takeaways

1. Use `try/catch` to handle expected exception boundaries.
2. Catch specific exceptions before general exceptions.
3. Use `finally` for cleanup.
4. Use `throw;` to rethrow while preserving stack trace.
5. Avoid `throw ex;`.
6. Use custom exceptions for domain-specific failures.
7. Use exception filters with `when`.
8. Do not use exceptions for normal control flow.
9. Prefer `TryParse` or `TryGetValue` for expected failures.
10. Async exceptions are caught around `await`.

## Java vs C#

| Java | C# |
|---|---|
| checked exceptions | no checked exceptions |
| try/catch/finally | try/catch/finally |
| throw | throw |
| throws declaration | no throws declaration |
| try-with-resources | using / await using |
| Optional parse pattern | TryParse / TryGetValue |
