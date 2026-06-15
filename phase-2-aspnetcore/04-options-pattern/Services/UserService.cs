using Microsoft.Extensions.Options;
using OptionsPatternDemo.Models;
using OptionsPatternDemo.Options;

namespace OptionsPatternDemo.Services;

public class UserService : IUserService
{
    private readonly UserSettingsOptions _settings;

    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
        new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" },
        new User { Id = 4, Name = "Diana", Email = "diana@example.com" }
    ];

    public UserService(IOptions<UserSettingsOptions> options)
    {
        _settings = options.Value;
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public List<User> GetPagedUsers()
    {
        return _users
            .Take(_settings.DefaultPageSize)
            .ToList();
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public User? Add(string name, string? email)
    {
        if (!_settings.AllowUserCreation)
        {
            return null;
        }

        int nextId = _users.Max(user => user.Id) + 1;

        string finalEmail = string.IsNullOrWhiteSpace(email)
            ? $"{name.ToLowerInvariant()}@{_settings.DefaultEmailDomain}"
            : email;

        User user = new()
        {
            Id = nextId,
            Name = name,
            Email = finalEmail
        };

        _users.Add(user);

        return user;
    }
}
