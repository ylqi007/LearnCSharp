using Records.Models;

namespace Records.Examples;

public static class ValueEqualityExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Value Equality Examples =====");

        var user1 = new UserRecord(
            "u001",
            "Alex",
            "alex@example.com");

        var user2 = new UserRecord(
            "u001",
            "Alex",
            "alex@example.com");

        // Both true since value equality
        Console.WriteLine($"Record user1 == user2: {user1 == user2}");
        Console.WriteLine($"Record Equals: {user1.Equals(user2)}");

        var classUser1 = new UserClass
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com"
        };

        var classUser2 = new UserClass
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com"
        };

        // Both false since referecne equality
        Console.WriteLine($"Class ReferenceEquals: {ReferenceEquals(classUser1, classUser2)}");
        Console.WriteLine($"Class Equals: {classUser1.Equals(classUser2)}");
    }
}
