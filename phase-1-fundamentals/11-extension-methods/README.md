# Project 11 - Extension Methods

## Goal
Learn how C# extension methods work, why LINQ looks like fluent instance methods, and when extension methods are useful or dangerous.

## Concepts
- `this` parameter in extension methods
- Static class + static method requirement
- Fluent APIs
- Extension methods over `string`, domain models, and `IEnumerable<T>`
- How LINQ-style chaining works
- Extension method limitations and best practices

## Java Comparison
Java has static utility methods:

```java
StringUtils.isEmail(value);
```

C# extension methods let static utility methods be called as if they were instance methods:

```csharp
value.IsEmail();
```

The method is still static. C# only changes the calling syntax.

## Run
From this folder:

```bash
dotnet run --project src/ExtensionMethodsDemo/ExtensionMethodsDemo.csproj
```

## Examples
- Example01: String extension methods
- Example02: Domain object extension methods
- Example03: Fluent chaining
- Example04: LINQ behind the scenes
- Example05: Custom enumerable extensions
- Example06: Extension method pitfalls

## Exercises
See `exercises/`.

## Interview Questions
1. What is an extension method?
2. Why must extension methods be declared in a static class?
3. Can extension methods override instance methods?
4. What does `this string value` mean?
5. Why does LINQ use extension methods?

## Key Takeaways
- Extension methods improve readability when used carefully.
- They are static methods with special syntax.
- LINQ is largely powered by extension methods over `IEnumerable<T>`.
- Do not hide important domain logic in surprising extension methods.
