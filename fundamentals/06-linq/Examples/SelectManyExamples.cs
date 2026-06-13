namespace Linq.Examples;

public static class SelectManyExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== SelectMany Examples =====");
        var orders = SampleData.GetOrders();

        var allProductIds = orders.SelectMany(order => order.ProductIds);
        Console.WriteLine("All product ids:");
        foreach (var productId in allProductIds) Console.WriteLine(productId);

        var uniqueProductIds = orders.SelectMany(order => order.ProductIds).Distinct();
        Console.WriteLine("Unique product ids:");
        foreach (var productId in uniqueProductIds) Console.WriteLine(productId);
    }
}
