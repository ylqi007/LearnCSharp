using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly Dictionary<string, User> _users = new()
    {
        ["u001"] = new("u001", "Alex", "alex@example.com", true),
        ["u002"] = new("u002", "Bob", "bob@example.com", false)
    };

    public User? GetById(string id)
    {
        return _users.TryGetValue(id, out User? user) ? user : null;
    }

    public IReadOnlyList<User> GetAll()
    {
        return _users.Values.ToList();
    }

    public void Save(User user)
    {
        _users[user.Id] = user;
    }
}
