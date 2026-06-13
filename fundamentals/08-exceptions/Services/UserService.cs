using Exceptions.Exceptions;
using Exceptions.Models;

namespace Exceptions.Services;

public class UserService
{
    private readonly Dictionary<string, User> _users = new()
    {
        ["u001"] = new User
        {
            Id = "u001",
            Name = "Alex",
            Email = "alex@example.com",
            IsActive = true
        },
        ["u002"] = new User
        {
            Id = "u002",
            Name = "Taylor",
            IsActive = false
        }
    };

    public User GetUserById(string userId)
    {
        if (!_users.TryGetValue(userId, out var user))
        {
            throw new UserNotFoundException(userId);
        }

        return user;
    }

    public User? TryGetUserById(string userId)
    {
        return _users.TryGetValue(userId, out var user)
            ? user
            : null;
    }
}
