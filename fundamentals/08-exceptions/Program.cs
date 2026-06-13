using Exceptions.Examples;

Console.WriteLine("=================================");
Console.WriteLine("08 - Exceptions");
Console.WriteLine("=================================");

BasicTryCatchExamples.Run();
MultipleCatchExamples.Run();
FinallyExamples.Run();
ThrowExamples.Run();
RethrowExamples.Run();
CustomExceptionExamples.Run();
ExceptionFilterExamples.Run();
ValidationExamples.Run();
TryParseExamples.Run();
AsyncExceptionExamples.RunAsync().GetAwaiter().GetResult();

Console.WriteLine();
Console.WriteLine("=================================");
Console.WriteLine("End of Demo");
Console.WriteLine("=================================");
