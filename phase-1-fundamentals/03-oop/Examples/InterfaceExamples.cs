using Oop.Interfaces;
using Oop.Models;

namespace Oop.Examples;

public static class InterfaceExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Interface Examples =====");

        IWorker worker = new Employee
        {
            Name = "Alex",
            Age = 34,
            EmployeeId = "E001",
            Department = "Azure Identity"
        };

        worker.Work();

        IManager manager = new Manager
        {
            Name = "Taylor",
            Age = 40,
            EmployeeId = "M001",
            Department = "Identity Platform",
            TeamSize = 8
        };

        manager.Manage();
    }
}
