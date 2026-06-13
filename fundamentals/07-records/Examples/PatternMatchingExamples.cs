using Records.Models;

namespace Records.Examples;

public static class PatternMatchingExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Pattern Matching Examples =====");

        var product = new ProductRecord(
            "p001",
            "Badminton Racket",
            "Sports",
            299.99M);

        string label = product switch
        {
            { Price: >= 1000 } => "Premium",
            { Price: >= 100 } => "Standard",
            _ => "Budget"
        };

        Console.WriteLine($"{product.Name}: {label}");

        var user = new UserRecord(
            "u001",
            "Alex",
            null);

        string emailStatus = user switch
        {
            { Email: not null } => "Has email",
            _ => "Missing email"
        };

        Console.WriteLine($"{user.Name}: {emailStatus}");
    }
}
