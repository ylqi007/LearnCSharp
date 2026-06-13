using AsyncAwait.Models;
using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class DependentVsIndependentExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Dependent vs Independent Task Examples =====");

        await IndependentTasksAsync();
        await DependentTasksAsync();
    }

    private static async Task IndependentTasksAsync()
    {
        Console.WriteLine();
        Console.WriteLine("[Independent Tasks]");

        var userService = new UserService();
        var tokenService = new TokenService();

        Task<User> userTask = userService.GetUserAsync("u001");

        Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(
            new TokenRequest
            {
                ClientId = "client-001",
                Scope = "api.read"
            });

        await Task.WhenAll(userTask, tokenTask);

        User user = await userTask;
        TokenResponse token = await tokenTask;

        Console.WriteLine(user);
        Console.WriteLine(token);
    }

    private static async Task DependentTasksAsync()
    {
        Console.WriteLine();
        Console.WriteLine("[Dependent Tasks]");

        var userService = new UserService();

        User user = await userService.GetUserAsync("u001");

        User manager = await userService.GetManagerAsync(user);

        Console.WriteLine(user);
        Console.WriteLine(manager);
    }
}
