using MiddlewareDemo.Models;

namespace MiddlewareDemo.Services;

public class UserService : IUserService
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
        new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" }
    ];

    public List<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(user => user.Id == id);

    public User Add(User user)
    {
        _users.Add(user);
        return user;
    }
}
