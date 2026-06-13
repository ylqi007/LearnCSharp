# 05 - Collections Summary

## Learning Objectives

Understand the most commonly used collection types in C#:

- Array
- List<T>
- Dictionary<TKey,TValue>
- HashSet<T>
- Queue<T>
- Stack<T>
- IReadOnlyList<T>
- Collection initialization
- Iteration
- Sorting

---

# Why Collections Matter

Collections are the foundation of everyday C# programming. You will use them in ASP.NET Core APIs, Azure SDKs, Entity Framework, logging, configuration, dependency injection, and LINQ.

Before learning LINQ, you need to understand the collection types that LINQ operates on.

---

# Array

An array is a fixed-size collection.

```csharp
string[] languages = ["Java", "TypeScript", "C#"];
```

Use arrays when size is fixed and you need fast index-based access.

Key members:

```csharp
Length
[index]
```

Limitation: arrays do not support dynamic Add or Remove.

---

# List<T>

`List<T>` is a dynamic array and the default general-purpose collection.

```csharp
List<string> languages = ["Java", "TypeScript", "C#"];
languages.Add("Python");
languages.Remove("Java");
```

Java equivalent: `ArrayList<T>`.

Use when you need ordered items, dynamic size, and index-based access.

---

# Dictionary<TKey,TValue>

`Dictionary<TKey,TValue>` stores key-value pairs.

```csharp
Dictionary<string, int> scores = new()
{
    ["Java"] = 90,
    ["C#"] = 95
};
```

Java equivalent: `HashMap<K,V>`.

Use when you need fast lookup by key.

Prefer:

```csharp
TryGetValue()
```

when the key may not exist.

---

# HashSet<T>

`HashSet<T>` stores unique values.

```csharp
HashSet<string> values = ["Java", "C#", "C#"];
```

The duplicate value is stored only once.

Use when you need uniqueness or fast membership checks.

Common operations:

```csharp
Contains()
IntersectWith()
UnionWith()
ExceptWith()
```

---

# Queue<T>

`Queue<T>` is FIFO: First In, First Out.

```csharp
Queue<string> queue = new();
queue.Enqueue("message-001");
queue.Dequeue();
```

Use for message processing, task scheduling, and BFS traversal.

---

# Stack<T>

`Stack<T>` is LIFO: Last In, First Out.

```csharp
Stack<string> stack = new();
stack.Push("Home");
stack.Pop();
```

Use for undo operations, navigation history, and DFS traversal.

---

# Collection Initialization

Traditional style:

```csharp
List<string> languages = new()
{
    "Java",
    "TypeScript",
    "C#"
};
```

Modern collection expression:

```csharp
List<string> languages =
[
    "Java",
    "TypeScript",
    "C#"
];
```

---

# Iteration

Use `foreach` by default:

```csharp
foreach (var user in users)
{
    Console.WriteLine(user.Name);
}
```

Use `for` when index matters:

```csharp
for (int i = 0; i < users.Count; i++)
{
    Console.WriteLine(users[i]);
}
```

Dictionary deconstruction:

```csharp
foreach (var (id, user) in usersById)
{
    Console.WriteLine($"{id} => {user.Name}");
}
```

---

# Sorting

```csharp
products.Sort((left, right) => left.Price.CompareTo(right.Price));
```

`Sort` mutates the list.

Later LINQ provides non-mutating alternatives:

```csharp
OrderBy()
OrderByDescending()
ThenBy()
```

---

# IReadOnlyList<T>

`IReadOnlyList<T>` exposes read-only access.

```csharp
IReadOnlyList<User> users = internalUsers;
```

It prevents callers from using `Add` or `Remove` through the interface.

Important: this is a read-only view, not true immutability. The original `List<T>` can still be modified internally.

---

# Java vs C#

| Java | C# |
|---|---|
| Array | Array |
| ArrayList<T> | List<T> |
| HashMap<K,V> | Dictionary<TKey,TValue> |
| HashSet<T> | HashSet<T> |
| Queue<T> | Queue<T> |
| Stack<T> | Stack<T> |
| Collections.unmodifiableList | IReadOnlyList<T> |
| Comparator | lambda comparison |

---

# Choosing the Right Collection

Use `Array` when size is fixed.

Use `List<T>` as the default dynamic collection.

Use `Dictionary<TKey,TValue>` for key-based lookup.

Use `HashSet<T>` for uniqueness.

Use `Queue<T>` for FIFO processing.

Use `Stack<T>` for LIFO processing.

Use `IReadOnlyList<T>` for read-only API boundaries.

---

# Most Important Takeaways

1. `List<T>` is the default general-purpose collection.
2. `Dictionary<TKey,TValue>` is the default key-value lookup collection.
3. `HashSet<T>` is for uniqueness.
4. `Queue<T>` is FIFO.
5. `Stack<T>` is LIFO.
6. `IReadOnlyList<T>` is useful for safe API boundaries.
7. Use `TryGetValue` when a dictionary key may be missing.
8. `Sort` mutates a list.
9. Collections are the foundation for LINQ.

---

# Next Step

```text
06-linq
```

LINQ builds directly on collections and is one of the most important modern C# features.
