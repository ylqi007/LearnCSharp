using Collections.Models;

namespace Collections.Examples;

public static class CollectionInitializationExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Collection Initialization Examples =====");

        List<string> oldStyle = new()
        {
            "Java",
            "TypeScript",
            "C#"
        };

        List<string> collectionExpression =
        [
            "Java",
            "TypeScript",
            "C#"
        ];

        Dictionary<string, Product> products = new()
        {
            ["p001"] = new Product { Id = "p001", Name = "Badminton Racket", Price = 299.99M },
            ["p002"] = new Product { Id = "p002", Name = "Running Shoes", Price = 129.99M }
        };

        Console.WriteLine("Old style:");
        foreach (var item in oldStyle) Console.WriteLine(item);

        Console.WriteLine("Collection expression:");
        foreach (var item in collectionExpression) Console.WriteLine(item);

        Console.WriteLine("Dictionary initialization:");
        foreach (var (id, product) in products)
        {
            Console.WriteLine($"{id} => {product}");
        }
    }
}
