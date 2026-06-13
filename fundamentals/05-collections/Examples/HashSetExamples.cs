namespace Collections.Examples;

public static class HashSetExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== HashSet<T> Examples =====");

        HashSet<string> uniqueLanguages =
        [
            "Java",
            "TypeScript",
            "C#",
            "C#",
            "Java"
        ];

        Console.WriteLine($"Unique count = {uniqueLanguages.Count}");

        foreach (var language in uniqueLanguages)
        {
            Console.WriteLine(language);
        }

        Console.WriteLine($"Contains C# = {uniqueLanguages.Contains("C#")}");

        HashSet<string> backendLanguages = ["Java", "C#", "Go"];
        HashSet<string> microsoftLanguages = ["C#", "TypeScript", "F#"];

        backendLanguages.IntersectWith(microsoftLanguages);

        Console.WriteLine("Intersection:");
        foreach (var language in backendLanguages)
        {
            Console.WriteLine(language);
        }
    }
}
