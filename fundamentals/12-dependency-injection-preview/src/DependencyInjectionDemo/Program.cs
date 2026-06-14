using DependencyInjectionDemo.Examples;

Console.WriteLine("Project 12 - Dependency Injection Preview");

Example01_TightCoupling.Run();
Example02_ConstructorInjection.Run();
Example03_FakeDependency.Run();
Example04_MultipleDependencies.Run();
Example05_MiniContainer.Run();
Example06_LifetimePreview.Run();

Console.WriteLine("\nDone.");
