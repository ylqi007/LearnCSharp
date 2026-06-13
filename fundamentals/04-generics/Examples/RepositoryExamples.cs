using Generics.Models;
using Generics.Repositories;

namespace Generics.Examples;

public static class RepositoryExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Repository Examples =====");

        var userRepository = new InMemoryRepository<User>();

        userRepository.Add(new User
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com"
        });

        userRepository.Add(new User
        {
            Id = "u002",
            Name = "Taylor"
        });

        foreach (var user in userRepository.GetAll())
        {
            Console.WriteLine(user);
        }

        var productRepository = new InMemoryRepository<Product>();

        productRepository.Add(new Product
        {
            Id = "p001",
            Name = "MacBook Pro",
            Price = 2499
        });

        foreach (var product in productRepository.GetAll())
        {
            Console.WriteLine(product);
        }

        var tokenRepository = new InMemoryRepository<Token>();

        tokenRepository.Add(new Token
        {
            Id = "t001",
            Value = "sample-token",
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        });

        foreach (var token in tokenRepository.GetAll())
        {
            Console.WriteLine($"{token}, IsExpired = {token.IsExpired()}");
        }
    }
}
