using Generics.Models;

namespace Generics.Examples;

public static class GenericConstraintExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Generic Constraint Examples =====");

        var user = new User
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com"
        };

        PrintEntityId(user);

        var emptyUser = CreateInstance<User>();
        Console.WriteLine($"Empty user id = '{emptyUser.Id}'");

        PrintReferenceType(user);

        // This does not compile because int is not a reference type:
        //
        // PrintReferenceType(123);
    }

    private static void PrintEntityId<T>(T entity)
        where T : IEntity
    {
        Console.WriteLine($"Entity id = {entity.Id}");
    }

    private static T CreateInstance<T>()
        where T : new()     // T 必须有一个 public 无参构造函数（parameterless constructor）。
    {
        return new T();
    }

    private static void PrintReferenceType<T>(T value)
        where T : class     // T 必须是引用类型
    {
        Console.WriteLine($"Reference type = {typeof(T).Name}, Value = {value}");
    }
}
