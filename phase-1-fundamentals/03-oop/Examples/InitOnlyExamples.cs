using Oop.Models;

namespace Oop.Examples;

public static class InitOnlyExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Init-only Property Examples =====");

        var profile = new UserProfile
        {
            UserId = "alex",
            DisplayName = "Alex Qi",
            Address = new Address(
                "1 Microsoft Way",
                "Redmond",
                "WA",
                "98052")
        };

        Console.WriteLine($"UserId = {profile.UserId}");
        Console.WriteLine($"DisplayName = {profile.DisplayName}");
        Console.WriteLine($"City = {profile.Address?.City}");

        // This does not compile because UserId is init-only:
        // profile.UserId = "new-id";
    }
}
