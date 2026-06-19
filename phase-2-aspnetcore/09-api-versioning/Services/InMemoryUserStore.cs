using ApiVersioningDemo.Models;

namespace ApiVersioningDemo.Services;

public class InMemoryUserStore : IUserStore
{
    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com", IsActive = true },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com", IsActive = true },
        new User { Id = 3, Name = "Charlie", Email = "charlie@example.com", IsActive = false }
    ];

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public User Add(User user)
    {
        _users.Add(user);

        return user;
    }

    public bool Deactivate(int id)
    {
        User? user = GetById(id);

        if (user is null)
        {
            return false;
        }

        user.IsActive = false;

        return true;
    }
}
