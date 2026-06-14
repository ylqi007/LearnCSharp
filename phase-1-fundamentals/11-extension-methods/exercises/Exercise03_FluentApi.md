# Exercise 03 - Fluent API

Create extension methods that allow this chain:

```csharp
string result = " alex qi "
    .TrimAndCollapseSpaces()
    .ToTitleCaseSimple()
    .Replace(" ", ".");
```
