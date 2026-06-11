# 02 - Types and Nullability

## 学习目标

理解现代 C# 最重要的特性：

* Nullable Reference Types
* string vs string?
* required
* ?.
* ??
* !
* Nullable Flow Analysis

这些特性在 Microsoft 内部 C# 服务代码中大量出现。

---

# 项目结构

```text
02-types-and-nullability
├── Program.cs
├── README.md
│
├── Models
│   ├── User.cs
│   ├── Product.cs
│   ├── Order.cs
│   └── UserProfile.cs
│
└── Examples
    ├── NullableReferenceExamples.cs
    ├── NullConditionalExamples.cs
    ├── NullCoalescingExamples.cs
    ├── RequiredExamples.cs
    └── NullForgivingExamples.cs
```

设计原则：

* Program.cs 只负责调用 Demo
* Models 放数据模型
* Examples 每个文件负责一个知识点

---

# Nullable Reference Types

.NET 8 项目：

```xml
<Nullable>enable</Nullable>
```

开启后：

```csharp
string  // 表示：永远不应该为 null
```

而：

```csharp
string? // 表示：允许为 null
```


---

# string vs string?

## string

```csharp
// 合法。
string name = "Alex";   

// 编译器警告：CS8600
// Converting null literal or possible null value to non-nullable type.
string name = null;     
```


---

## string?

```csharp
string? middleName = null;  // 合法。
```


---

# Nullable Flow Analysis

示例：

```csharp
string? email = GetEmail();

if (email != null)
{
    Console.WriteLine(email.Length);
}
```

编译器自动推导：

```text
进入 if 后
email 不可能为 null
```

因此不会产生警告。

这称为：

```text
Nullable Flow Analysis
```

---

# Null Conditional Operator

语法：

```csharp
?.
```

示例：

```csharp
User? user = null;

string? email = user?.Email;
```

不会抛异常。

结果：

```text
email = null
```

Java 对应：

```java
user == null
    ? null
    : user.getEmail();
```

---

# Null Coalescing Operator

语法：

```csharp
??
```

示例：

```csharp
string? email = null;

string displayName =
    email ?? "Unknown User";
```

结果：

```text
Unknown User
```

含义：

```text
如果左边是 null
则返回右边
```

---

# required

示例：

```csharp
public class User
{
    public required string UserId { get; set; }
}
```

创建对象：

```csharp
var user = new User
{
    UserId = "alex"
};
```

合法。

---

如果：

```csharp
var user = new User();
```

编译器报错：

```text
CS9035
Required member must be set.
```

作用：

```text
保证对象初始化完整
```

---

# Null Forgiving Operator

语法：

```csharp
!
```

示例：

```csharp
string? value = null;

Console.WriteLine(value!.Length);
```

编译器：

```text
不报警告
```

因为：

```text
告诉编译器：

请相信我
这里不是 null
```

---

但是：

```text
运行时仍可能崩溃
```

结果：

```text
NullReferenceException
```

因此：

```text
! 只影响编译器
不影响运行时
```

---

# value vs value!

## value

```csharp
value.Length
```

编译器：

```text
CS8602
Dereference of a possibly null reference.
```

---

## value!

```csharp
value!.Length
```

编译器：

```text
✓ 不警告
```

运行：

```text
仍可能 NullReferenceException
```

---

# 常见 Warning

## CS8600

```text
Converting null literal or possible null value
to non-nullable type.
```

示例：

```csharp
string name = null;
```

---

## CS8602

```text
Dereference of a possibly null reference.
```

示例：

```csharp
string? value = null;

Console.WriteLine(value.Length);
```

---

## CS8618

```text
Non-nullable property must contain
a non-null value.
```

示例：

```csharp
public string Name { get; set; }
```

但未初始化。

---

## CS9035

```text
Required member must be set.
```

示例：

```csharp
var user = new User();
```

而 UserId 为 required。

---

# Models 设计

## User

```csharp
public class User
{
    public required string UserId { get; set; }

    public string? Email { get; set; }

    public string? DisplayName { get; set; }
}
```

---

## Product

```csharp
public class Product
{
    public required string ProductId { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }
}
```

---

## Order

```csharp
public class Order
{
    public required string OrderId { get; set; }

    public User? Customer { get; set; }

    public Product? Product { get; set; }
}
```

---

## UserProfile

```csharp
public class UserProfile
{
    public User? User { get; set; }

    public string? Bio { get; set; }
}
```

用于练习：

```csharp
profile?.User?.Email
```

---

# Program.cs 设计原则

Program.cs：

```csharp
NullableReferenceExamples.Run();

NullConditionalExamples.Run();

NullCoalescingExamples.Run();

RequiredExamples.Run();

NullForgivingExamples.Run();
```

职责：

```text
程序入口
```

而不是：

```text
500 行 Main()
```

---

# Java 对照

| Java                       | C#                     |
| -------------------------- | ---------------------- |
| String                     | string                 |
| Optional                   | string?                |
| Objects.requireNonNullElse | ??                     |
| null-safe access 手写判断   | ?.                     |
| Lombok @NonNull            | required               |
| NPE                        | NullReferenceException |

---

# 本章结论

必须掌握：

```csharp
string?

?.

??

required

!
```

因为这些特性在：

* ASP.NET Core
* Azure SDK
* Azure Identity
* Microsoft 内部服务

中极其常见。

---

# 下一步

```text
03-oop
```

但快速完成即可。

重点留给：

```text
06-linq
10-async-await
```

这两章对实际工作价值最高。
