namespace TypesAndNullability.Examples;

public static class NullableReferenceExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Nullable Reference Examples =====");

        NonNullableString();

        NullableString();

        NullableFlowAnalysis();

        NullReferenceExceptionDemo();
    }

    // 编译警告:
    // CS8600
    // string invalidName = null;
    private static void NonNullableString()
    {
        Console.WriteLine();
        Console.WriteLine("== [Non-Nullable String] ==");

        string name = "Alex";
        // string name = null;

        Console.WriteLine(name);
    }


    private static void NullableString()
    {
        Console.WriteLine();
        Console.WriteLine("[Nullable String]");

        string? middleName = null;

        Console.WriteLine(middleName ?? "Middle name not provided");
    }

    private static void NullableFlowAnalysis()
    {
        Console.WriteLine();
        Console.WriteLine("[Nullable Flow Analysis]");

        string? email = GetEmail();

        if (email != null)
        {
            Console.WriteLine($"Email length = {email.Length}");
        }
        else
        {
            Console.WriteLine("Email is null");
        }
    }

    private static void NullReferenceExceptionDemo()
    {
        Console.WriteLine();
        Console.WriteLine("[Null Reference Demo]");

        string? value = null;

        try
        {
            // 编译器警告:
            // CS8602
            //
            // Console.WriteLine(value.Length);

            Console.WriteLine(value!.Length);    // 不要滥用 !
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("NullReferenceException thrown");
        }
    }

    private static string? GetEmail()
    {
        return DateTime.Now.Second % 2 == 0 ? "alex@example.com" : null;
    }
}