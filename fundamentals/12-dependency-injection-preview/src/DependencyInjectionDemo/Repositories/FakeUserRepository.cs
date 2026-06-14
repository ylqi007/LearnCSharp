using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Repositories;

public sealed class FakeUserRepository : IUserRepository
{
    public User? GetById(string id)
    {
        return new User(id, "Fake User", "fake@example.com", true);
    }

    public IReadOnlyList<User> GetAll()
    {
        return [new User("fake-1", "Fake User", "fake@example.com", true)];
    }

    public void Save(User user)
    {
        Console.WriteLine($"Fake save: {user}");
    }
}
