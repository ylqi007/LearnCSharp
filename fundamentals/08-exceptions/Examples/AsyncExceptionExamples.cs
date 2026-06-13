using Exceptions.Exceptions;
using Exceptions.Models;
using Exceptions.Services;

namespace Exceptions.Examples;

public static class AsyncExceptionExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== Async Exception Examples =====");

        var tokenService = new TokenService();

        try
        {
            var response = await tokenService.IssueTokenAsync(new TokenRequest
            {
                ClientId = "client-async",
                ClientSecret = "invalid-secret",
                Scope = "api.read"
            });

            Console.WriteLine(response);
        }
        catch (AuthenticationFailedException ex)
        {
            Console.WriteLine($"Async authentication failed: {ex.Message}");
        }
    }
}
