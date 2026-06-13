using Exceptions.Exceptions;
using Exceptions.Models;
using Exceptions.Services;

namespace Exceptions.Examples;

public static class ExceptionFilterExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Exception Filter Examples =====");

        var tokenService = new TokenService();

        try
        {
            tokenService.IssueToken(new TokenRequest
            {
                ClientId = "client-001",
                ClientSecret = "invalid-secret",
                Scope = "api.read"
            });
        }
        catch (AuthenticationFailedException ex) when (ex.ClientId == "client-001")
        {
            Console.WriteLine($"Filtered catch for client-001: {ex.Message}");
        }
        catch (AuthenticationFailedException ex)
        {
            Console.WriteLine($"Authentication failed: {ex.Message}");
        }
    }
}
