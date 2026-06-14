using TypesAndNullability.Models;

namespace TypesAndNullability.Examples;

public static class NullConditionalExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Null Conditional Examples =====");

        User? user = null;

        string? email = user?.Email;

        Console.WriteLine(
            email ?? "Email not available");

        user = new User
        {
            UserId = "alex",
            Email = "alex@example.com"
        };

        email = user?.Email;

        Console.WriteLine(email);
    }
}