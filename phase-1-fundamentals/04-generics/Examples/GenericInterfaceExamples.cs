using Generics.Interfaces;
using Generics.Models;
using Generics.Repositories;

namespace Generics.Examples;

public static class GenericInterfaceExamples
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("===== Generic Interface Examples =====");

        IRepository<User> userRepository = new InMemoryRepository<User>();

        userRepository.Add(new User
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com"
        });

        var user = userRepository.GetById("u001");

        Console.WriteLine(user);

        Console.WriteLine();
        
        IRepository<Product> productRepository = new InMemoryRepository<Product>();
        
        productRepository.Add(new Product
        {
            Id = "Product-001",
            Name = "Badminton Racket",
            Price = 299.99M
        });

        var product = productRepository.GetById("Product-001");
        Console.WriteLine(product);
    }
}
