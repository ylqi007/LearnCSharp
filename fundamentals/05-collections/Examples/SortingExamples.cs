using Collections.Models;

namespace Collections.Examples;

public static class SortingExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Sorting Examples =====");

        List<Product> products =
        [
            new Product { Id = "p001", Name = "Badminton Racket", Price = 299.99M },
            new Product { Id = "p002", Name = "Running Shoes", Price = 129.99M },
            new Product { Id = "p003", Name = "Laptop", Price = 1499.99M }
        ];

        products.Sort((left, right) => left.Price.CompareTo(right.Price));

        Console.WriteLine("Sorted by price ascending:");
        foreach (var product in products) Console.WriteLine(product);

        products.Sort((left, right) => string.Compare(left.Name, right.Name, StringComparison.Ordinal));

        Console.WriteLine("Sorted by name ascending:");
        foreach (var product in products) Console.WriteLine(product);
    }
}
