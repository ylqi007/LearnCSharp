using Oop.Models;

namespace Oop.Examples;

public static class ClassExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Class Examples =====");

        var person = new Person
        {
            Name = "Alex",
            Age = 34
        };

        Console.WriteLine(person.GetDescription());
    }
}
