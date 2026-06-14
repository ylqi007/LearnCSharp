namespace Linq.Examples;

public static class GroupByExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== GroupBy Examples =====");
        var users = SampleData.GetUsers();

        var usersByDepartment = users.GroupBy(user => user.Department);
        foreach (var group in usersByDepartment)
        {
            Console.WriteLine($"Department = {group.Key}");
            foreach (var user in group) Console.WriteLine($"  {user.Name} - {user.Salary:C0}");
        }

        var averageSalaryByDepartment = users
            .GroupBy(user => user.Department)
            .Select(group => new { Department = group.Key, AverageSalary = group.Average(user => user.Salary) });

        Console.WriteLine("Average salary by department:");
        foreach (var item in averageSalaryByDepartment) Console.WriteLine($"{item.Department}: {item.AverageSalary:C0}");
    }
}
