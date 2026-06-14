using Oop.Interfaces;

namespace Oop.Models;

public class Employee : Person, IWorker
{
    public required string EmployeeId { get; init; }

    public string Department { get; init; } = "General";

    public virtual string GetRole()
    {
        return "Employee";
    }

    public void Work()
    {
        Console.WriteLine($"{Name} is working in {Department}.");
    }

    public override string GetDescription()
    {
        return $"{Name}, EmployeeId = {EmployeeId}, Department = {Department}";
    }
}
