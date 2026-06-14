using MinimalApi.Models;

namespace MinimalApi.Services;

public class UserService
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
    ];

    public List<User> GetAll() => _users;

    public void Add(User user)
    {
        _users.Add(user);
    }
}
