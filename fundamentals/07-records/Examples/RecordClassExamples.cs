using Records.Models;

namespace Records.Examples;

public static class RecordClassExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Record Class Examples =====");

        var token = new TokenRecord
        {
            TokenType = "Bearer",
            AccessToken = "sample-token",
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };

        Console.WriteLine(token);
        Console.WriteLine($"IsExpired = {token.IsExpired()}");

        var expiredToken = token with
        {
            ExpiresAt = DateTime.UtcNow.AddMinutes(-5)
        };

        Console.WriteLine(expiredToken);
        Console.WriteLine($"IsExpired = {expiredToken.IsExpired()}");
    }
}
