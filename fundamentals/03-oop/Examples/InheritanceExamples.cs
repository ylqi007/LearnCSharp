using Oop.Models;

namespace Oop.Examples;

public static class InheritanceExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Inheritance Examples =====");

        var employee = new Employee
        {
            Name = "Alex",
            Age = 34,
            EmployeeId = "E001",
            Department = "Azure Identity"
        };

        Console.WriteLine(employee.GetDescription());
        Console.WriteLine(employee.GetRole());

        var manager = new Manager
        {
            Name = "Taylor",
            Age = 40,
            EmployeeId = "M001",
            Department = "Identity Platform",
            TeamSize = 8
        };

        Console.WriteLine(manager.GetDescription());
        Console.WriteLine(manager.GetRole());
    }
}
