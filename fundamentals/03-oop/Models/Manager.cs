using Oop.Interfaces;

namespace Oop.Models;

public sealed class Manager : Employee, IManager
{
    public int TeamSize { get; init; }

    public override string GetRole()
    {
        return "Manager";
    }

    public void Manage()
    {
        Console.WriteLine($"{Name} is managing a team of {TeamSize} people.");
    }

    public override string GetDescription()
    {
        return $"{Name}, Manager, TeamSize = {TeamSize}";
    }
}
