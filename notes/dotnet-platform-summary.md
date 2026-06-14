# LearnCSharp - .NET Platform 总结

## 核心结论

`.NET` 是一个开发平台生态，不只是一个版本号。

可以把它理解成：

```text
C# code
  ↓
.NET SDK 编译
  ↓
.NET Runtime 运行
  ↓
Application
```

最重要的关系：

```text
.NET ecosystem
├── .NET Framework 1.0 -> 4.8.1
│   └── 老一代，Windows-only，主要用于维护旧项目
│
└── .NET Core 1.0 -> 3.1
    └── 新一代，跨平台，开源
        └── 从 .NET 5 开始改名为 ".NET"
            ├── .NET 5
            ├── .NET 6
            ├── .NET 7
            ├── .NET 8
            ├── .NET 9
            └── .NET 10
```

所以：

- `.NET Framework` 是旧分支
- `.NET Core` 是新分支的早期名字
- `.NET 5+` 是 `.NET Core` 的延续
- `.NET 8`、`.NET 9`、`.NET 10` 都是现代 `.NET`

---

# .NET Framework

`.NET Framework` 是最早的 .NET 平台。

特点：

- 主要运行在 Windows
- 常见于老的企业项目
- 常见技术包括 WinForms、WPF、ASP.NET Framework
- 最新主线版本是 `.NET Framework 4.8.1`
- 仍然有安全支持，但不是新项目的首选

典型项目文件：

```xml
<TargetFramework>net481</TargetFramework>
```

适合场景：

- 维护老项目
- 公司已有大量 Windows-only 代码
- 老版本 ASP.NET、WinForms、WPF 项目

不建议用于新的普通项目。

---

# .NET Core

`.NET Core` 是 Microsoft 对 .NET 的现代化重写。

特点：

- 跨平台：Windows、macOS、Linux
- 开源
- 更适合云、容器、Web API、微服务
- 支持 side-by-side 安装多个版本
- 版本从 `.NET Core 1.0` 到 `.NET Core 3.1`

从 `.NET 5` 开始，Microsoft 去掉了名字里的 `Core`。

也就是说：

```text
.NET Core 3.1
  ↓
.NET 5
  ↓
.NET 6
  ↓
.NET 7
  ↓
.NET 8
  ↓
.NET 9
  ↓
.NET 10
```

`.NET 5+` 不是 `.NET Framework` 的下一版，而是 `.NET Core` 的下一代命名。

---

# .NET 5, 6, 7, 8, 9, 10

这些都是现代 `.NET` 的版本。

可以类比：

```text
Java 17, Java 21
Python 3.10, 3.11, 3.12
Node.js 18, 20, 22
```

常见项目文件：

```xml
<TargetFramework>net8.0</TargetFramework>
```

或：

```xml
<TargetFramework>net10.0</TargetFramework>
```

含义：

- `net8.0` 表示项目目标平台是 `.NET 8`
- `net9.0` 表示项目目标平台是 `.NET 9`
- `net10.0` 表示项目目标平台是 `.NET 10`

---

# LTS 和 STS

现代 `.NET` 每年发布一个大版本，通常在 11 月。

版本分两种支持周期：

## LTS

Long Term Support，长期支持版本。

特点：

- 支持时间更长
- 适合生产项目
- 偶数版本通常是 LTS

例子：

```text
.NET 6
.NET 8
.NET 10
```

## STS

Standard Term Support，标准支持版本。

特点：

- 支持时间较短
- 更适合尝鲜新功能
- 奇数版本通常是 STS

例子：

```text
.NET 7
.NET 9
```

---

# 当前建议

学习或新项目建议使用现代 `.NET`。

优先选择：

```text
.NET 10
```

如果教程或项目使用 `.NET 8`，也仍然很常见，因为 `.NET 8` 是 LTS。

避免新项目使用：

```text
.NET Framework
.NET Core 1.x
.NET Core 2.x
.NET Core 3.x
.NET 5
.NET 6
.NET 7
```

其中 `.NET Framework` 主要用于老项目维护，其他旧版现代 `.NET` 多数已经结束支持。

---

# C# 和 .NET 的关系

`C#` 是语言。

`.NET` 是运行 C# 程序的平台。

关系类似：

```text
C# : .NET
Java : JVM
JavaScript/TypeScript : Node.js or Browser
Python : CPython Runtime
```

写 C# 时，通常会用：

- C# language
- .NET SDK
- .NET Runtime
- .NET Base Class Library
- NuGet packages

---

# SDK 和 Runtime

## SDK

SDK 用来开发、编译、运行、打包项目。

常用命令：

```bash
dotnet new console
dotnet build
dotnet run
dotnet test
dotnet publish
```

开发机器需要安装 SDK。

## Runtime

Runtime 只负责运行已经编译好的应用。

生产服务器如果不编译代码，通常只需要 Runtime。

简单理解：

```text
SDK = 开发 + 编译 + 运行
Runtime = 只运行
```

---

# ASP.NET Core

`ASP.NET Core` 是现代 `.NET` 上的 Web 框架。

用途：

- Web API
- Web App
- Minimal API
- MVC
- Razor Pages
- SignalR
- Blazor

名字里还有 `Core`，但它是现代 Web 框架，不等于旧的 `.NET Core` 版本线。

常见组合：

```text
C# + .NET 8 + ASP.NET Core
C# + .NET 10 + ASP.NET Core
```

---

# 如何判断一个项目用的是哪个 .NET

看 `.csproj` 文件中的 `TargetFramework`。

现代 `.NET`：

```xml
<TargetFramework>net8.0</TargetFramework>
```

旧 `.NET Framework`：

```xml
<TargetFramework>net481</TargetFramework>
```

多个目标平台：

```xml
<TargetFrameworks>net8.0;net481</TargetFrameworks>
```

---

# 记忆方式

最简单的记法：

```text
.NET Framework = old Windows .NET
.NET Core = modern cross-platform .NET before rename
.NET 5+ = modern .NET after rename
.NET 8/9/10 = version numbers of modern .NET
```

新项目默认想：

```text
C# + .NET 10
```

维护老项目时才重点关注：

```text
.NET Framework 4.8 / 4.8.1
```

