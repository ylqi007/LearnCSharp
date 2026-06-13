using AsyncAwait.Models;
using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class IdentityTokenExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Identity Token Async Examples =====");

        var tokenService = new TokenService();
        var userService = new UserService();

        Task<TokenResponse> tokenTask = tokenService.GetTokenAsync(
            new TokenRequest
            {
                ClientId = "managed-identity-client",
                Scope = "https://management.azure.com/.default"
            });

        Task<List<Models.User>> usersTask = userService.GetUsersAsync();

        await Task.WhenAll(tokenTask, usersTask);

        TokenResponse token = await tokenTask;
        List<Models.User> users = await usersTask;

        Console.WriteLine(token);

        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}
