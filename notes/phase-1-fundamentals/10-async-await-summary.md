# 10 - Async / Await Summary

## Core Idea

Async programming allows a program to wait for I/O without blocking a thread.

Common I/O:

- HTTP calls
- database queries
- file reads
- Azure SDK calls
- token acquisition
- network operations

---

## Task

`Task` represents future work.

```csharp
Task task = Task.Delay(1000);
await task;
```

Task is not the same as Thread.

---

## Task<T>

`Task<T>` represents future work that returns a value.

```csharp
async Task<User> GetUserAsync(string id)
{
    await Task.Delay(300);
    return user;
}
```

---

## async

`async` allows a method to use `await`.

Async methods usually return:

- `Task`
- `Task<T>`
- `IAsyncEnumerable<T>`

Avoid `async void` except event handlers.

---

## await

`await` waits for a task without blocking the thread.

```csharp
var user = await userService.GetUserAsync("u001");
```

Avoid:

```csharp
task.Result
task.Wait()
```

---

## Dependent vs Independent Tasks

This is one of the most important async design decisions.

Ask:

```text
Does task B need task A's result before it can start?
```

If yes, tasks are dependent.

If no, tasks are independent.

---

### Case 1: B does not depend on A

Example:

```text
Get User
Get Token
```

They can run independently.

```csharp
Task<User> userTask = userService.GetUserAsync(userId);

Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(request);

await Task.WhenAll(userTask, tokenTask);

User user = await userTask;
TokenResponse token = await tokenTask;
```

The two tasks start before awaiting.

Total time is roughly:

```text
max(A, B)
```

not:

```text
A + B
```

---

### Case 2: B depends on A

Example:

```text
Get User
↓
Get Manager by User
```

```csharp
User user = await userService.GetUserAsync(userId);

User manager = await userService.GetManagerAsync(user);
```

This must be sequential.

Total time is:

```text
A + B
```

because B cannot start before A finishes.

---

### Case 3: Partial Dependency

Example:

```text
A = Get Token
B = Get Config

C = Call API
    depends on A + B
```

Correct pattern:

```csharp
Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(request);
Task<AppConfig> configTask = configService.GetConfigAsync();

await Task.WhenAll(tokenTask, configTask);

TokenResponse token = await tokenTask;
AppConfig config = await configTask;

ApiResult result = await apiService.CallApiWithTokenAsync(token, config);
```

This is the Fan-Out / Fan-In pattern.

---

## Fan-Out / Fan-In Pattern

Fan-Out:

```text
start multiple independent async operations
```

Fan-In:

```text
wait for all of them and combine results
```

Example:

```csharp
var taskA = AAsync();
var taskB = BAsync();
var taskC = CAsync();

await Task.WhenAll(taskA, taskB, taskC);

var a = await taskA;
var b = await taskB;
var c = await taskC;
```

Use this often in service code when multiple I/O calls are independent.

---

## Why await individual tasks after Task.WhenAll?

```csharp
await Task.WhenAll(tokenTask, usersTask);

TokenResponse token = await tokenTask;
List<User> users = await usersTask;
```

The later awaits do not run tasks again.

They only retrieve results from already completed tasks.

---

## Best Practices

1. Prefer async all the way.
2. Avoid `.Result` and `.Wait()`.
3. Use `Task.WhenAll` for independent I/O.
4. Use sequential awaits for dependent calls.
5. Use Fan-Out / Fan-In for partial dependency graphs.
6. Pass `CancellationToken` when possible.
7. Catch exceptions around `await`.
8. Avoid `async void`.
9. Materialize tasks before awaiting when concurrency is desired.
10. Remember that awaiting a completed task only retrieves its result.
