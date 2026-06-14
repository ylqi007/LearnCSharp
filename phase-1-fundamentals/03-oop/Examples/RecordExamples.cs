using Oop.Models;

namespace Oop.Examples;

public static class RecordExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Record Examples =====");

        var address1 = new Address(
            "1 Microsoft Way",
            "Redmond",
            "WA",
            "98052");

        var address2 = new Address(
            "1 Microsoft Way",
            "Redmond",
            "WA",
            "98052");

        Console.WriteLine(address1);
        Console.WriteLine($"address1 == address2: {address1 == address2}");

        var updatedAddress = address1 with
        {
            City = "Bellevue"
        };

        Console.WriteLine(updatedAddress);
    }
}
