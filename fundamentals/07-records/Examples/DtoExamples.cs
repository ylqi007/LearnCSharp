using Records.Models;

namespace Records.Examples;

public static class DtoExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== DTO Examples =====");

        var user = new UserRecord(
            "u001",
            "Alex",
            "alex@example.com");

        var response = ApiResponseRecord<UserRecord>.Ok(user);

        PrintResponse(response);

        var failedResponse = ApiResponseRecord<UserRecord>.Fail(
            "User not found");

        PrintResponse(failedResponse);
    }

    private static void PrintResponse<T>(ApiResponseRecord<T> response)
    {
        if (response.Success)
        {
            Console.WriteLine($"Success: {response.Data}");
        }
        else
        {
            Console.WriteLine($"Error: {response.ErrorMessage}");
        }
    }
}
