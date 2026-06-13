# 09 - Delegates and Events

## Learning Objectives

Understand delegates, built-in delegate types, lambdas, callbacks, and events in C#.

Topics:

- delegate
- Func
- Action
- Predicate
- lambda expressions
- callbacks
- events
- EventHandler<T>
- multicast delegates
- LINQ delegate usage

## Run

```bash
dotnet run
```

## Key Takeaways

1. A delegate is a type-safe reference to a method.
2. `Func<T>` represents a method that returns a value.
3. `Action<T>` represents a method that returns void.
4. `Predicate<T>` represents a method returning bool.
5. Lambdas are concise inline functions.
6. LINQ methods accept delegates.
7. Events are built on top of delegates.
8. `EventHandler<TEventArgs>` is the standard .NET event pattern.
9. Delegates can be multicast.
10. Events are commonly used for notifications.

## Java vs C#

| Java | C# |
|---|---|
| Functional interface | delegate / Func / Action |
| lambda | lambda |
| Consumer<T> | Action<T> |
| Function<T,R> | Func<T,R> |
| Predicate<T> | Predicate<T> / Func<T,bool> |
| Observer pattern | events |
| Listener | event handler |

## Next Step

```text
10-async-await
```
