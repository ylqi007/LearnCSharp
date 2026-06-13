namespace DelegatesAndEvents.Examples;

public static class MulticastDelegateExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Multicast Delegate Examples =====");

        Action<string> pipeline = StepOne;
        pipeline += StepTwo;
        pipeline += StepThree;

        pipeline("token-request");

        pipeline -= StepTwo;

        Console.WriteLine("After removing StepTwo:");
        pipeline("token-request");
    }

    private static void StepOne(string value) => Console.WriteLine($"StepOne processing {value}");
    private static void StepTwo(string value) => Console.WriteLine($"StepTwo processing {value}");
    private static void StepThree(string value) => Console.WriteLine($"StepThree processing {value}");
}
