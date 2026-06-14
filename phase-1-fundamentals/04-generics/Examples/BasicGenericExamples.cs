namespace Generics.Examples;

public static class BasicGenericExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Basic Generic Examples =====");

        List<String> languages = 
        [
            "Java",
            "TypeScript",
            "C#"    
        ];

        Dictionary<string, int> scores = new()
        {
            ["Java"] = 90,
            ["TypeScript"] = 85,
            ["C#"] = 95
        };

        foreach (var language in languages)
        {
            Console.WriteLine($"{language}: {scores[language]}");
        }
    }

    public static void Run1()
    {
        Console.WriteLine();
        Console.WriteLine("===== Basic Generic Examples =====");

        List<string> languages =
        [
            "Java",
            "TypeScript",
            "C#"
        ];

        Dictionary<string, int> scores = new()
        {
            ["Java"] = 90,
            ["TypeScript"] = 85,
            ["C#"] = 95
        };

        foreach (var language in languages)
        {
            Console.WriteLine($"{language}: {scores[language]}");
        }
    }
}
