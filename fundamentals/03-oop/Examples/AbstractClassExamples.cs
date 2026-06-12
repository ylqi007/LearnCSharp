using Oop.Abstracts;

namespace Oop.Examples;

public static class AbstractClassExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Abstract Class Examples =====");

        WorkerBase worker = new SoftwareEngineer
        {
            Name = "Alex",
            PrimaryLanguage = "C#"
        };

        worker.PrintName();
        worker.Work();
    }

    private class SoftwareEngineer : WorkerBase
    {
        public required string PrimaryLanguage { get; init; }

        public override void Work()
        {
            Console.WriteLine($"{Name} writes code in {PrimaryLanguage}.");
        }
    }
}
