using Records.Models;

namespace Records.Examples;

public static class NestedRecordExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Nested Record Examples =====");

        var address = new AddressRecord(
            "1 Microsoft Way",
            "Redmond",
            "WA",
            "98052");

        var profile = new UserProfileRecord(
            "u001",
            "Alex Qi",
            address);

        Console.WriteLine(profile);

        var movedProfile = profile with
        {
            Address = profile.Address with
            {
                City = "Bellevue"
            }
        };

        Console.WriteLine(movedProfile);
    }
}
