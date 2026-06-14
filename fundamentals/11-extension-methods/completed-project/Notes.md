# Completed Project Notes - Project 11

## What You Learned
- Extension methods are static methods with instance-like syntax.
- `this string value` means the method extends `string`.
- LINQ methods such as `Where`, `Select`, and `OrderBy` are extension methods.
- Extension methods are useful for fluent APIs and small reusable helpers.

## Java Comparison
Java usually uses utility classes:

```java
StringUtils.maskEmail(email);
```

C# can write:

```csharp
email.MaskEmail();
```

The C# method is still static; the syntax is different.

## Best Practices
- Use extension methods for small, generic operations.
- Avoid putting complex business workflows inside extension methods.
- Avoid names that conflict with existing instance methods.
