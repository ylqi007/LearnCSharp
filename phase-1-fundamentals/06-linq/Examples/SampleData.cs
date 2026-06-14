using Linq.Models;

namespace Linq.Examples;

public static class SampleData
{
    public static List<User> GetUsers()
    {
        return
        [
            new User { Id = "u001", Name = "Alex", Department = "Azure Identity", Salary = 166000, Email = "alex@example.com" },
            new User { Id = "u002", Name = "Taylor", Department = "Azure Identity", Salary = 185000, Email = "taylor@example.com" },
            new User { Id = "u003", Name = "Jordan", Department = "Payments", Salary = 145000 },
            new User { Id = "u004", Name = "Morgan", Department = "Security", Salary = 210000, Email = "morgan@example.com" },
            new User { Id = "u005", Name = "Casey", Department = "Payments", Salary = 130000 }
        ];
    }

    public static List<Product> GetProducts()
    {
        return
        [
            new Product { Id = "p001", Name = "Badminton Racket", Category = "Sports", Price = 299.99M },
            new Product { Id = "p002", Name = "Running Shoes", Category = "Sports", Price = 129.99M },
            new Product { Id = "p003", Name = "Laptop", Category = "Electronics", Price = 1499.99M },
            new Product { Id = "p004", Name = "Monitor", Category = "Electronics", Price = 399.99M },
            new Product { Id = "p005", Name = "Notebook", Category = "Office", Price = 9.99M }
        ];
    }

    public static List<Order> GetOrders()
    {
        return
        [
            new Order { Id = "o001", UserId = "u001", ProductIds = ["p001", "p005"], CreatedAt = new DateTime(2026, 1, 10) },
            new Order { Id = "o002", UserId = "u002", ProductIds = ["p003", "p004"], CreatedAt = new DateTime(2026, 1, 15) },
            new Order { Id = "o003", UserId = "u001", ProductIds = ["p002"], CreatedAt = new DateTime(2026, 2, 1) },
            new Order { Id = "o004", UserId = "u004", ProductIds = ["p003", "p005"], CreatedAt = new DateTime(2026, 2, 8) }
        ];
    }
}
