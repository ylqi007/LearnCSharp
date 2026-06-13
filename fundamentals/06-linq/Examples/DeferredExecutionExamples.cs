namespace Linq.Examples;

public static class DeferredExecutionExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Deferred Execution Examples =====");
        var users = SampleData.GetUsers();

        var query = users.Where(user =>
        {
            Console.WriteLine($"Filtering {user.Name}");
            return user.Salary >= 160000;
        });

        Console.WriteLine("Query created, but not executed yet.");

        Console.WriteLine("==> First enumeration:");
        foreach (var user in query) Console.WriteLine($"Result: {user.Name}");

        Console.WriteLine("==> Second enumeration:");
        foreach (var user in query) Console.WriteLine($"Result: {user.Name}");

        Console.WriteLine("==> Materialized with ToList:");
        var materialized = query.ToList();
        foreach (var user in materialized) Console.WriteLine($"Materialized: {user.Name}");
    }
}
