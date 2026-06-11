# LearnCSharp - 目录与项目结构设计

## 目标

建立一个长期可维护的 C# 学习仓库。

要求：

- 管理多个 C# Project
- 管理学习笔记
- 与 GitHub 同步
- 支持 VS Code
- 支持 Solution (.sln)
- 后续扩展 ASP.NET Core、Azure Identity 等内容

---

# 推荐目录结构

```text
~/Work/LearnCSharp
├── LearnCSharp.sln
├── README.md
│
├── notes
│   ├── 01-console-basics-summary.md
│   ├── csharp.md
│   ├── linq.md
│   ├── async-await.md
│   ├── aspnet-core.md
│   └── azure-identity.md
│
├── fundamentals
│   ├── 01-console-basics
│   ├── 02-types-and-nullability
│   ├── 03-oop
│   ├── 04-generics
│   ├── 05-collections
│   ├── 06-linq
│   └── 07-async-await
│
├── dotnet
│   ├── 01-cli
│   ├── 02-csproj
│   └── 03-nuget
│
├── aspnet-core
│   ├── 01-minimal-api
│   ├── 02-controller-api
│   ├── 03-dependency-injection
│   └── 04-authentication
│
├── data-access
│   ├── 01-ef-core-basics
│   └── 02-repository-pattern
│
└── azure-identity
    ├── 01-managed-identity
    ├── 02-msal
    ├── 03-token-validation
    └── 04-dpop
```

---

# 为什么这样组织

## LearnCSharp

整个学习仓库。

作用：

```text
Git Repository
Workspace Root
Solution Root
Knowledge Base Root
```

---

## notes

专门存放学习笔记。

例如：

```text
notes
├── csharp.md
├── linq.md
├── async-await.md
└── aspnet-core.md
```

建议：

- 使用 Markdown
- 与代码分离
- 每个项目对应一篇总结

---

## fundamentals

学习 C# 语言本身。

例如：

```text
fundamentals
├── 01-console-basics
├── 02-types-and-nullability
├── 03-oop
└── 04-generics
```

说明：

- 分类目录不加编号
- 子项目加编号
- 保证排序

---

## dotnet

学习 .NET 平台。

内容包括：

```text
dotnet CLI
csproj
NuGet
Build System
MSBuild
```

---

## aspnet-core

学习 Web API。

内容包括：

```text
Minimal API
Controllers
Middleware
Dependency Injection
Authentication
Authorization
```

---

## azure-identity

与你当前 Microsoft Azure Identity 工作最相关。

内容包括：

```text
Managed Identity
MSAL
OAuth
OpenID Connect
DPoP
Token Validation
```

---

# VS Code 打开方式

不推荐：

```bash
cd ~/Work/LearnCSharp/fundamentals/01-console-basics
code .
```

因为只能看到一个项目。

---

推荐：

```bash
cd ~/Work/LearnCSharp
code .
```

Explorer：

```text
LearnCSharp
├── notes
├── fundamentals
├── dotnet
├── aspnet-core
└── azure-identity
```

---

# Solution (.sln)

当项目越来越多时：

```text
fundamentals
├── 01-console-basics
├── 02-types-and-nullability
└── 03-oop
```

VS Code 不知道应该运行哪个 Project。

因此需要：

```text
LearnCSharp.sln
```

创建：

```bash
dotnet new sln -n LearnCSharp
```

---

添加项目：

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

# Workspace

推荐创建：

```text
LearnCSharp.code-workspace
```

以后直接打开：

```bash
code ~/Work/LearnCSharp.code-workspace
```

---

# Git 管理建议

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

否则会形成：

```text
Nested Git Repository
```

增加复杂度。

---

# 推荐的 .gitignore

```gitignore
bin/
obj/
.vs/
.vscode/

*.user
*.suo
```

---

# 学习路线

```text
fundamentals
│
├── 01-console-basics
├── 02-types-and-nullability
├── 03-oop
├── 04-generics
├── 05-collections
├── 06-linq
├── 07-records
├── 08-exceptions
├── 09-delegates-and-events
└── 10-async-await
```

重点优先级：

1. Nullable Reference Types
2. LINQ
3. async/await
4. Dependency Injection
5. ASP.NET Core
