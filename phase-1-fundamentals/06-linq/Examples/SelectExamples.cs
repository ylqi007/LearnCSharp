namespace Linq.Examples;

public static class SelectExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Select Examples =====");
        var users = SampleData.GetUsers();

        var names = users.Select(user => user.Name);
        Console.WriteLine("Names:");
        foreach (var name in names) Console.WriteLine(name);

        var summaries = users.Select(user => new { user.Name, user.Department, AnnualSalary = user.Salary });
        Console.WriteLine("Anonymous projections:");
        foreach (var summary in summaries) Console.WriteLine($"{summary.Name} - {summary.Department} - {summary.AnnualSalary:C0}");
    }
}
