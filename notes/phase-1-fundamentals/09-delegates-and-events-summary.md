# 09 - Delegates and Events Summary

## What is a Delegate?

A delegate is a type-safe reference to a method.

```csharp
private delegate int MathOperation(int left, int right);
```

Any method matching this signature can be assigned to this delegate.

Delegates allow behavior to be passed as data.

---

## Func

`Func` represents a method that returns a value.

```csharp
Func<int, int, int> add = (left, right) => left + right;
```

The last generic type is the return type.

---

## Action

`Action` represents a method that returns void.

```csharp
Action<string> print = message => Console.WriteLine(message);
```

Use it for side effects such as logging, printing, and notifications.

---

## Predicate

`Predicate<T>` represents a method that takes T and returns bool.

```csharp
Predicate<User> isActive = user => user.IsActive;
```

It is similar to `Func<T, bool>`.

---

## Lambda Expressions

A lambda is an inline function.

```csharp
user => user.IsActive
```

LINQ heavily depends on lambdas.

---

## Callbacks

A callback is behavior passed into another method.

```csharp
ProcessData(input, onSuccess, onError);
```

In C#, callbacks are often represented with `Action<T>` or `Func<T>`.

---

## Events

Events are built on top of delegates.

```csharp
public event EventHandler<OrderCreatedEventArgs>? OrderCreated;
```

Subscribe:

```csharp
orderService.OrderCreated += handler;
```

Unsubscribe:

```csharp
orderService.OrderCreated -= handler;
```

Raise:

```csharp
OrderCreated?.Invoke(this, args);
```

---

## EventHandler<TEventArgs>

Standard .NET event pattern:

```csharp
void Handler(object? sender, TEventArgs e)
```

This is common in .NET libraries and UI/event-driven systems.

---

## Multicast Delegates

A delegate can reference multiple methods.

```csharp
Action<string> pipeline = StepOne;
pipeline += StepTwo;
pipeline += StepThree;
```

Invoking it calls all registered methods.

---

## Delegates and LINQ

LINQ uses delegates:

```csharp
Where(Func<T, bool>)
Select(Func<T, TResult>)
```

Example:

```csharp
users.Where(user => user.IsActive)
```

The lambda is compiled into a delegate.

---

## Java vs C#

| Java | C# |
|---|---|
| Functional interface | delegate |
| Consumer<T> | Action<T> |
| Function<T,R> | Func<T,R> |
| Predicate<T> | Predicate<T> / Func<T,bool> |
| Observer pattern | event |
| Listener | event handler |
| lambda | lambda |

---

## Key Takeaways

1. Delegates represent methods as values.
2. `Func` returns a value.
3. `Action` returns void.
4. `Predicate` returns bool.
5. Lambdas are inline delegate implementations.
6. Callbacks pass behavior into methods.
7. Events are delegate-based notifications.
8. `EventHandler<T>` is the standard .NET event pattern.
9. Delegates can be multicast.
10. LINQ is built on delegates.
