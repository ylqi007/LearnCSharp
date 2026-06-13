# 05 - Collections

## Learning Objectives

Understand the most commonly used C# collection types and when to use each one.

Topics:

- Array
- List<T>
- Dictionary<TKey, TValue>
- HashSet<T>
- Queue<T>
- Stack<T>
- Collection initialization
- Iteration patterns
- Sorting
- IReadOnlyList<T>

---

## Why Collections Matter

Collections are everywhere in modern C# and .NET. Before learning LINQ, it is important to understand the collection types LINQ operates on.

---

## Project Structure

```text
05-collections
├── Program.cs
├── Models
│   ├── User.cs
│   ├── Product.cs
│   └── Order.cs
└── Examples
    ├── ArrayExamples.cs
    ├── ListExamples.cs
    ├── DictionaryExamples.cs
    ├── HashSetExamples.cs
    ├── QueueExamples.cs
    ├── StackExamples.cs
    ├── CollectionInitializationExamples.cs
    ├── IterationExamples.cs
    ├── SortingExamples.cs
    └── ReadOnlyCollectionExamples.cs
```

---

## Run

```bash
dotnet run
```

---

## Core Collection Types

### Array

Fixed-size collection. Use when size is known and does not change.

### List<T>

Dynamic array. This is the default general-purpose collection.

Java equivalent: `ArrayList<T>`.

### Dictionary<TKey, TValue>

Key-value lookup collection.

Java equivalent: `HashMap<K,V>`.

Prefer `TryGetValue()` when the key may not exist.

### HashSet<T>

Unique-value collection. Useful for membership checks and set operations.

### Queue<T>

FIFO: First In, First Out.

### Stack<T>

LIFO: Last In, First Out.

### IReadOnlyList<T>

Exposes read-only collection access. Useful for API boundaries.

---

## Java vs C#

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

## Key Takeaways

1. `List<T>` is the default general-purpose collection.
2. `Dictionary<TKey,TValue>` is used for fast key-based lookup.
3. `HashSet<T>` guarantees uniqueness.
4. `Queue<T>` is FIFO.
5. `Stack<T>` is LIFO.
6. `IReadOnlyList<T>` is useful for API boundaries.
7. Collection initialization is concise in modern C#.
8. Collections are the foundation for LINQ.

---

## Next Step

```text
06-linq
```
