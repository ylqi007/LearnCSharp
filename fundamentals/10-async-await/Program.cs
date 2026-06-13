using AsyncAwait.Examples;

Console.WriteLine("=================================");
Console.WriteLine("10 - Async / Await");
Console.WriteLine("=================================");

// await BasicTaskExamples.RunAsync();
// await AsyncAwaitExamples.RunAsync();
// await TaskOfTExamples.RunAsync();
// await SequentialVsConcurrentExamples.RunAsync();
await DependentVsIndependentExamples.RunAsync();
// await FanOutFanInExamples.RunAsync();
// await TaskWhenAllExamples.RunAsync();
// await TaskWhenAnyExamples.RunAsync();
// await CancellationTokenExamples.RunAsync();
// await AsyncExceptionExamples.RunAsync();
// await AsyncStreamExamples.RunAsync();
// await IdentityTokenExamples.RunAsync();

Console.WriteLine();
Console.WriteLine("=================================");
Console.WriteLine("End of Demo");
Console.WriteLine("=================================");
