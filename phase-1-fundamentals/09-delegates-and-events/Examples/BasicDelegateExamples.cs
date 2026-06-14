namespace DelegatesAndEvents.Examples;

public static class BasicDelegateExamples
{
    private delegate int MathOperation(int left, int right);

    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Basic Delegate Examples =====");

        MathOperation add = Add;
        MathOperation multiply = Multiply;

        Console.WriteLine($"Add = {add(3, 4)}");
        Console.WriteLine($"Multiply = {multiply(3, 4)}");

        MathOperation operation = DateTime.Now.Second % 2 == 0 ? Add : Multiply;
        Console.WriteLine($"Dynamic operation = {operation(5, 6)}");
    }

    private static int Add(int left, int right) => left + right;
    private static int Multiply(int left, int right) => left * right;
}
