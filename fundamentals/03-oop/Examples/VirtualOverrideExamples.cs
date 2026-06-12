using Oop.Models;

namespace Oop.Examples;

public static class VirtualOverrideExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Virtual / Override Examples =====");

        Employee employee = new()
        {
            Name = "Alex",
            Age = 34,
            EmployeeId = "E001",
            Department = "Azure Identity"
        };

        Employee managerAsEmployee = new Manager
        {
            Name = "Taylor",
            Age = 40,
            EmployeeId = "M001",
            Department = "Identity Platform",
            TeamSize = 8
        };

        Console.WriteLine(employee.GetRole());
        Console.WriteLine(managerAsEmployee.GetRole());
    }
}
