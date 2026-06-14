namespace ExtensionMethodsDemo.Examples;

public static class Example06_Pitfalls
{
    public static void Run()
    {
        Console.WriteLine("\n--- Example 06: Pitfalls ---");
        Console.WriteLine("1. Extension methods do not override real instance methods.");
        Console.WriteLine("2. Too many extension methods can hide business logic.");
        Console.WriteLine("3. Extension methods should usually be simple and unsurprising.");
    }
}
