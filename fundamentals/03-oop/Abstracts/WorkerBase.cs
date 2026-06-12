namespace Oop.Abstracts;

public abstract class WorkerBase
{
    public required string Name { get; init; }

    public abstract void Work();

    public virtual void PrintName()
    {
        Console.WriteLine($"Worker name: {Name}");
    }
}
