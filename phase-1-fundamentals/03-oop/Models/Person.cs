namespace Oop.Models;

public class Person
{
    public required string Name { get; init; }

    public int Age { get; init; }

    public virtual string GetDescription()
    {
        return $"{Name}, Age {Age}";
    }
}
