using ExtensionMethodsDemo.Extensions;
using ExtensionMethodsDemo.Models;

namespace ExtensionMethodsDemo.Examples;

public static class Example02_UserExtensions
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 02: User Extensions ---");

        var user = new User(
            Id: "u001",
            Name: "Alex Qi",
            Email: "alex.qi@example.com",
            IsActive: true,
            CreatedAtUtc: DateTime.UtcNow.AddDays(-3));

        Console.WriteLine(user.DisplayName());
        Console.WriteLine(user.WasCreatedWithinDays(7));
        Console.WriteLine(user.ToAuditLine());
    }
}
