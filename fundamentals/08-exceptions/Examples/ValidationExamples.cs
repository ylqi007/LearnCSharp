using Exceptions.Exceptions;
using Exceptions.Models;
using Exceptions.Services;

namespace Exceptions.Examples;

public static class ValidationExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Validation Examples =====");

        var tokenService = new TokenService();

        try
        {
            tokenService.IssueToken(new TokenRequest
            {
                ClientId = "client-001",
                ClientSecret = null,
                Scope = "api.read"
            });
        }
        catch (InvalidTokenRequestException ex)
        {
            Console.WriteLine($"Invalid request: {ex.Message}");
        }

        try
        {
            var response = tokenService.IssueToken(new TokenRequest
            {
                ClientId = "client-001",
                ClientSecret = "valid-secret",
                Scope = "api.read"
            });

            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected exception: {ex.Message}");
        }
    }
}
