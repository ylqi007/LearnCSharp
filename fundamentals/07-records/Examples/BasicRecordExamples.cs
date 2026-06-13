using Records.Models;

namespace Records.Examples;

public static class BasicRecordExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Basic Record Examples =====");

        var user = new UserRecord(
            "u001",
            "Alex",
            "alex@example.com");

        Console.WriteLine(user);

        Console.WriteLine($"Id = {user.Id}");
        Console.WriteLine($"Name = {user.Name}");
        Console.WriteLine($"Email = {user.Email}");
    }
}
