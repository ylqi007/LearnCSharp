namespace Collections.Examples;

public static class ArrayExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Array Examples =====");

        string[] languages =
        [
            "Java",
            "TypeScript",
            "C#"
        ];

        Console.WriteLine($"Array length = {languages.Length}");

        for (int i = 0; i < languages.Length; i++)
        {
            Console.WriteLine($"languages[{i}] = {languages[i]}");
        }

        int[] scores = new int[3];
        scores[0] = 90;
        scores[1] = 85;
        scores[2] = 95;

        Console.WriteLine($"First score = {scores[0]}");
    }
}
