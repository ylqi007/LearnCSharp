# LearnCSharp - 01-console-basics 总结

## 项目目标

第一个 C# 项目的目标不是学习编程，而是理解：

- C# Project 如何组织
- .NET 如何编译
- .NET 如何运行
- VS Code 如何调试
- C# 与 Java 的区别

项目路径：

```text
~/Work/LearnCSharp/fundamentals/01-console-basics
```

---

# 项目结构

```text
01-console-basics
├── .vscode
│   └── launch.json
├── Models
│   └── Person.cs
├── bin
├── obj
├── 01-console-basics.csproj
└── Program.cs
```

## Program.cs

程序入口文件。

现代 C# 使用 Top-level Statements：

```csharp
Console.WriteLine("Hello World");
```

编译器实际会生成：

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
    }
}
```

结论：

- Main() 才是真正入口
- Program.cs 只是默认文件名
- 文件名可以修改

---

## Models

仅用于组织代码。

常见目录：

```text
Models
Services
Repositories
Controllers
DTOs
```

.NET 不强制要求目录结构。

---

## Person.cs

定义一个类：

```csharp
public class Person
{
    public required string Name { get; set; }
    public int Age { get; set; }
}
```

对应 Java：

```java
private String name;

public String getName() {}
public void setName(String name) {}
```

C# Property：

```csharp
public string Name { get; set; }
```

自动生成 field、getter、setter。

---

# .csproj

最重要的配置文件。

对应：

- Maven: pom.xml
- Gradle: build.gradle

示例：

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <RootNamespace>ConsoleBasics</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

## OutputType

```xml
<OutputType>Exe</OutputType>
```

生成可执行程序。

如果改成：

```xml
<OutputType>Library</OutputType>
```

则变成类库。

---

## TargetFramework

```xml
<TargetFramework>net8.0</TargetFramework>
```

指定目标运行时。

推荐：

- 学习：net8.0
- 企业项目：net8.0 (LTS)

修改后执行：

```bash
dotnet clean
dotnet build
```

---

## RootNamespace

决定默认 namespace。

推荐：

```xml
<RootNamespace>ConsoleBasics</RootNamespace>
```

避免：

```xml
<RootNamespace>_01_console_basics</RootNamespace>
```

---

## ImplicitUsings

```xml
<ImplicitUsings>enable</ImplicitUsings>
```

自动导入常用 namespace。

例如：

```csharp
List<string>
Console.WriteLine()
```

无需手动 using。

---

## Nullable

```xml
<Nullable>enable</Nullable>
```

启用 Nullable Reference Types。

```csharp
string
```

表示不能为 null。

```csharp
string?
```

表示允许为 null。

---

# CS8618 警告

例如：

```csharp
public class Person
{
    public string Name { get; set; }
}
```

编译器警告：

```text
CS8618
```

原因：

Name 被声明为非空，但没有初始化。

解决方案：

```csharp
public required string Name { get; set; }
```

或：

```csharp
public string Name { get; set; } = string.Empty;
```

或：

```csharp
public string? Name { get; set; }
```

---

# 编译

编译命令：

```bash
dotnet build
```

流程：

```text
Program.cs
Person.cs
    ↓
Roslyn Compiler
    ↓
01-console-basics.dll
```

---

# 为什么没有 Person.dll

一个 Project 默认生成一个 Assembly。

```text
01-console-basics.dll
```

包含：

- Program
- Person
- 其它类

不会生成：

```text
Person.dll
```

---

# 运行

运行：

```bash
dotnet run
```

实际执行：

```bash
dotnet build
dotnet bin/Debug/net8.0/01-console-basics.dll
```

也可以直接：

```bash
dotnet bin/Debug/net8.0/01-console-basics.dll
```

---

# bin 与 obj

## bin

最终编译产物。

类似 Java：

```text
target/
```

常见文件：

```text
01-console-basics.dll
01-console-basics.pdb
runtimeconfig.json
deps.json
```

---

## obj

编译缓存。

类似：

```text
target/classes
```

中的中间文件。

不要修改。

不要提交 Git。

---

# dotnet clean

执行：

```bash
dotnet clean
```

并不完全等于：

```bash
rm -rf bin obj
```

学习阶段推荐：

```bash
rm -rf bin obj
dotnet build
```

观察整个构建过程。

---

# 调试

VS Code：

```text
F5
```

成功标志：

```text
Symbols loaded
Program exited with code 0
```

---

## launch.json

作用：

告诉 VS Code 如何启动调试器。

相当于 IntelliJ 的 Run Configuration。

---

# 学到的 C# 语法

## var

```csharp
var person = new Person();
```

等价于：

```csharp
Person person = new Person();
```

---

## Object Initializer

```csharp
var person = new Person
{
    Name = "Alex",
    Age = 34
};
```

---

## String Interpolation

```csharp
Console.WriteLine($"Hello {name}");
```

---

## Collection Expression

```csharp
List<string> skills =
[
    "Java",
    "TypeScript",
    "C#"
];
```

---

## foreach

```csharp
foreach (var skill in skills)
{
    Console.WriteLine(skill);
}
```

---

# Java vs C# 对照

| Java | C# |
|--------|--------|
| main() | Main() |
| Application.java | Program.cs |
| package | namespace |
| pom.xml | .csproj |
| Maven | MSBuild |
| target | bin |
| target/classes | obj |
| mvn compile | dotnet build |
| mvn clean | dotnet clean |
| java -jar | dotnet xxx.dll |
| Spring Boot | ASP.NET Core |

---

# 下一步

建议进入：

```text
02-types-and-nullability
```

重点学习：

```csharp
string
string?
required
null
??
?.
!
var
readonly
const
```

其中 Nullable Reference Types 是现代 C# 最重要的特性之一。


---

# 附录：LearnCSharp Workspace 与项目管理

## 推荐目录结构

```text
~/Work/LearnCSharp
├── LearnCSharp.sln
├── README.md
├── notes
│   ├── 01-console-basics-summary.md
│   ├── csharp.md
│   ├── linq.md
│   └── async-await.md
│
├── fundamentals
│   ├── 01-console-basics
│   ├── 02-types-and-nullability
│   ├── 03-oop
│   ├── 04-generics
│   └── 05-linq
│
├── dotnet
├── aspnet-core
├── data-access
└── azure-identity
```

设计原则：

- LearnCSharp 是整个学习仓库
- notes 专门存放 Markdown 笔记
- fundamentals 学习 C# 语言
- dotnet 学习 .NET 平台
- aspnet-core 学习 Web API
- azure-identity 学习与 Azure Identity 工作相关内容

---

## VS Code 打开哪个目录

不推荐：

```bash
cd ~/Work/LearnCSharp/fundamentals/01-console-basics
code .
```

因为 Explorer 只能看到当前项目。

推荐：

```bash
cd ~/Work/LearnCSharp
code .
```

这样 Explorer 会显示整个学习仓库。

---

## 为什么需要 Solution

当项目越来越多时：

```text
fundamentals
├── 01-console-basics
├── 02-types-and-nullability
└── 03-oop
```

VS Code 不知道应该运行哪个 Project。

因此建议创建 Solution：

```bash
cd ~/Work/LearnCSharp

dotnet new sln -n LearnCSharp
```

生成：

```text
LearnCSharp.sln
```

---

## 添加项目到 Solution

例如：

```bash
dotnet sln add fundamentals/01-console-basics/01-console-basics.csproj

dotnet sln add fundamentals/02-types-and-nullability/02-types-and-nullability.csproj

dotnet sln add fundamentals/03-oop/03-oop.csproj
```

查看：

```bash
dotnet sln list
```

---

## Workspace 的作用

VS Code Workspace 类似 IntelliJ Project。

推荐保存：

```text
LearnCSharp.code-workspace
```

以后直接打开：

```bash
code ~/Work/LearnCSharp.code-workspace
```

---

## Git 管理建议

推荐：

```text
LearnCSharp
↓
一个 Git Repository
```

不要：

```text
LearnCSharp 是一个 Repo

01-console-basics 又是一个 Repo

02-oop 又是一个 Repo
```

否则会出现 Nested Git Repository。

学习阶段推荐：

```text
LearnCSharp
├── notes
├── fundamentals
├── aspnet-core
└── azure-identity
```

全部统一管理。

---

## 下一步学习路线

```text
01-console-basics
    ↓
02-types-and-nullability
    ↓
03-oop
    ↓
04-generics
    ↓
05-collections
    ↓
06-linq
    ↓
07-records
    ↓
08-exceptions
    ↓
09-delegates-and-events
    ↓
10-async-await
```

其中优先级最高：

1. Nullable Reference Types
2. LINQ
3. async/await
4. Dependency Injection
