namespace DelegatesAndEvents.Examples;

public static class FuncExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Func Examples =====");

        Func<int, int, int> add = (left, right) => left + right;
        Func<string, int> getLength = value => value.Length;

        Console.WriteLine($"Add = {add(10, 20)}");
        Console.WriteLine($"Length = {getLength("Azure Identity")}");
    }
}
