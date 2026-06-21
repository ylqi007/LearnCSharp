using HealthChecksDemo.Models;

namespace HealthChecksDemo.Services;

public class UserService : IUserService
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
    ];

    public List<User> GetAll()
    {
        return _users;
    }
}
