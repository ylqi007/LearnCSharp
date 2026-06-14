# 10 - Async / Await

## Learning Objectives

Understand asynchronous programming in C#.

Topics:

- Task
- Task<T>
- async
- await
- Sequential vs concurrent async calls
- Dependent vs independent async tasks
- Fan-Out / Fan-In pattern
- Task.WhenAll
- Task.WhenAny
- CancellationToken
- Async exception handling
- IAsyncEnumerable
- Identity/token async scenarios

## Run

```bash
dotnet run
```

## Key Takeaways

1. `Task` represents future work.
2. `Task<T>` represents future work that returns a value.
3. `async` allows a method to use `await`.
4. `await` waits without blocking the current thread.
5. If task B depends on task A's result, use sequential awaits.
6. If task B does not depend on task A's result, start both tasks first and use `Task.WhenAll`.
7. `Task.WhenAll` waits for multiple tasks.
8. After `Task.WhenAll`, awaiting individual tasks retrieves results; it does not run them again.
9. Fan-Out / Fan-In means starting independent tasks, waiting for all, then continuing with combined results.
10. `Task.WhenAny` waits for the first completed task.
11. `CancellationToken` enables cooperative cancellation.
12. Async exceptions are caught around `await`.
13. `IAsyncEnumerable<T>` supports async streams.
14. Avoid `.Result` and `.Wait()`.
15. Prefer async all the way.

## Dependent vs Independent Tasks

### Independent

```csharp
Task<User> userTask = userService.GetUserAsync(userId);
Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(request);

await Task.WhenAll(userTask, tokenTask);

User user = await userTask;
TokenResponse token = await tokenTask;
```

### Dependent

```csharp
User user = await userService.GetUserAsync(userId);

User manager = await userService.GetManagerAsync(user);
```

## Fan-Out / Fan-In

```csharp
Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(request);
Task<AppConfig> configTask = configService.GetConfigAsync();

await Task.WhenAll(tokenTask, configTask);

TokenResponse token = await tokenTask;
AppConfig config = await configTask;

ApiResult result = await apiService.CallApiWithTokenAsync(token, config);
```

## Java vs C#

| Java | C# |
|---|---|
| CompletableFuture<T> | Task<T> |
| future.get() | await task |
| CompletableFuture.allOf | Task.WhenAll |
| CompletableFuture.anyOf | Task.WhenAny |
| cancellation | CancellationToken |
| async stream alternatives | IAsyncEnumerable<T> |
