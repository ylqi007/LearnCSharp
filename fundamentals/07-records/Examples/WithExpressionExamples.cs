using Records.Models;

namespace Records.Examples;


// with 的意思是：
// 创建一个 copy，只修改指定字段。
// 不会修改 original。
public static class WithExpressionExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== With Expression Examples =====");

        var original = new ProductRecord(
            "p001",
            "Badminton Racket",
            "Sports",
            299.99M);

        var discounted = original with
        {
            Price = 249.99M
        };

        var recategorized = original with
        {
            Category = "Fitness"
        };

        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"Discounted: {discounted}");
        Console.WriteLine($"Recategorized: {recategorized}");
    }
}
