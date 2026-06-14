using ControllerApi.Models;

namespace ControllerApi.Services;

public class UserService
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
    ];

    public List<User> GetAll() => _users;

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public User Add(User user)
    {
        _users.Add(user);
        return user;
    }
}
