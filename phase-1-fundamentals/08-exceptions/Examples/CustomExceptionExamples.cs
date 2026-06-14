using Exceptions.Exceptions;
using Exceptions.Services;

namespace Exceptions.Examples;

public static class CustomExceptionExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Custom Exception Examples =====");

        var userService = new UserService();

        try
        {
            var user = userService.GetUserById("u999");
            Console.WriteLine(user);
        }
        catch (UserNotFoundException ex)
        {
            Console.WriteLine($"Custom exception caught: {ex.Message}");
            Console.WriteLine($"Missing UserId = {ex.UserId}");
        }
    }
}
