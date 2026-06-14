# Project 02 - Controller API

## Objective

This project introduces ASP.NET Core Controller-based Web API development.

Project 01 used Minimal API:

```csharp
app.MapGet("/users", ...);
```

Project 02 uses Controllers:

```csharp
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
}
```

The goal is to understand the most common enterprise-style way to organize ASP.NET Core HTTP endpoints.

---

## Learning Goals

After completing this project, you should understand:

- What a Controller is
- What an Action method is
- How attribute routing works
- How `[ApiController]` changes API behavior
- How `ControllerBase` provides helper methods
- How constructor injection works in Controllers
- How Controller API compares with Minimal API

---

## Project Structure

```text
02-controller-api/
├── 02-controller-api.csproj
├── Program.cs
├── Controllers/
│   └── UsersController.cs
├── Models/
│   └── User.cs
├── Services/
│   └── UserService.cs
├── test.http
├── README.md
└── Summary.md
```

---

## Key Files

### Program.cs

Application startup file.

Responsibilities:

- Create `WebApplicationBuilder`
- Register Controllers
- Register services
- Map Controller routes
- Start the web server

Important lines:

```csharp
builder.Services.AddControllers();

app.MapControllers();
```

`AddControllers()` registers Controller support.

`MapControllers()` enables attribute-routed Controllers.

---

### Controllers/UsersController.cs

Defines HTTP endpoints using Controller syntax.

Important attributes:

```csharp
[ApiController]
[Route("api/users")]
```

Important methods:

```csharp
[HttpGet]
public IActionResult GetUsers()
```

```csharp
[HttpGet("{id:int}")]
public IActionResult GetUserById(int id)
```

```csharp
[HttpPost]
public IActionResult CreateUser(User user)
```

---

## Endpoints

### GET /

Returns a simple greeting.

```http
GET /
```

Response:

```text
Hello Controller API
```

### GET /api/users

Returns all users.

```http
GET /api/users
```

### GET /api/users/{id}

Returns one user by id.

```http
GET /api/users/1
```

If found:

```text
200 OK
```

If not found:

```text
404 Not Found
```

### POST /api/users

Creates a new user.

Request:

```json
{
  "id": 3,
  "name": "Charlie",
  "email": "charlie@example.com"
}
```

Response:

```text
201 Created
```

---

## Running the Project

```bash
dotnet restore
dotnet run
```

The app will print a local URL such as:

```text
Now listening on: http://localhost:5118
```

Update `test.http` if your port is different.

---

## Testing with REST Client

Install the VS Code extension:

```text
REST Client
```

Open:

```text
test.http
```

Click `Send Request` above each request.

---

## Minimal API vs Controller API

| Topic | Minimal API | Controller API |
|---|---|---|
| Style | Function-based | Class-based |
| Main location | Program.cs | Controllers folder |
| Routing | `MapGet`, `MapPost` | `[HttpGet]`, `[HttpPost]` |
| Good for | Small APIs, simple services | Enterprise APIs |
| Organization | Can become crowded | More structured |
| Common in large teams | Less common | More common |

---

## Java / Spring Boot Mapping

| ASP.NET Core | Spring Boot |
|---|---|
| `UsersController` | `UserController` |
| `[ApiController]` | `@RestController` |
| `[Route("api/users")]` | `@RequestMapping("/api/users")` |
| `[HttpGet]` | `@GetMapping` |
| `[HttpPost]` | `@PostMapping` |
| `ControllerBase` | Base controller behavior |
| `IActionResult` | `ResponseEntity<?>` |
| Constructor injection | Constructor injection |

---

## What Comes Next

Project 03 will focus on Dependency Injection in more depth.

It will introduce:

- Interfaces
- `IUserService`
- `AddSingleton`
- `AddScoped`
- `AddTransient`
- Service lifetimes
