namespace Linq.Examples;

public static class OrderByExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== OrderBy Examples =====");
        var users = SampleData.GetUsers();

        var orderedBySalary = users.OrderBy(user => user.Salary);
        Console.WriteLine("Salary ascending:");
        foreach (var user in orderedBySalary) Console.WriteLine(user);

        var orderedByDepartmentThenSalary = users
            .OrderBy(user => user.Department)
            .ThenByDescending(user => user.Salary);

        Console.WriteLine("Department ascending, salary descending:");
        foreach (var user in orderedByDepartmentThenSalary) Console.WriteLine(user);
    }
}
