using Generics.Models;

namespace Generics.Examples;

public static class GenericClassExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Generic Class Examples =====");

        var success = ApiResponse<string>.Ok("Token issued successfully");
        PrintResponse(success);

        var failed = ApiResponse<string>.Fail("Invalid client credentials");
        PrintResponse(failed);

        var userResponse = ApiResponse<User>.Ok(new User
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com"
        });

        PrintResponse(userResponse);
    }

    private static void PrintResponse<T>(ApiResponse<T> response)
    {
        if (response.Success)
        {
            Console.WriteLine($"Success: {response.Data}");
        }
        else
        {
            Console.WriteLine($"Error: {response.ErrorMessage}");
        }
    }
}
