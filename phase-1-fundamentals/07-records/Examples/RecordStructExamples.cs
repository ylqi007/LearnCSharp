using Records.Models;

namespace Records.Examples;

public static class RecordStructExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Record Struct Examples =====");

        var point1 = new PointRecordStruct(10, 20);
        var point2 = new PointRecordStruct(10, 20);

        Console.WriteLine(point1);
        Console.WriteLine($"point1 == point2: {point1 == point2}");

        var movedPoint = point1 with
        {
            X = 30
        };

        Console.WriteLine($"Moved point: {movedPoint}");

        Console.WriteLine($"point1 == moved point: {point1 == movedPoint}");
    }
}
