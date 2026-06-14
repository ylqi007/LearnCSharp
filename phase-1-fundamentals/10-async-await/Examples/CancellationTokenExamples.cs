using AsyncAwait.Models;
using AsyncAwait.Services;

namespace AsyncAwait.Examples;

public static class CancellationTokenExamples
{
    public static async Task RunAsync()
    {
        Console.WriteLine();
        Console.WriteLine("===== CancellationToken Examples =====");

        var tokenService = new TokenService();

        using var cts = new CancellationTokenSource();
        cts.CancelAfter(500);

        try
        {
            var response = await tokenService.GetTokenWithCancellationAsync(
                new TokenRequest
                {
                    ClientId = "client-001",
                    Scope = "api.read"
                },
                cts.Token);

            Console.WriteLine(response);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Token request was canceled.");
        }
    }
}
