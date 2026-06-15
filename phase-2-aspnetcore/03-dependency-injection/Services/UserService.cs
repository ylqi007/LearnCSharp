using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

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

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public User Add(User user)
    {
        _users.Add(user);

        return user;
    }

    public bool Delete(int id)
    {
        User? user = GetById(id);

        if (user is null)
        {
            return false;
        }

        _users.Remove(user);

        return true;
    }
}
