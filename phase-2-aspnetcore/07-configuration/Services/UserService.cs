using ConfigurationDemo.Models;
using ConfigurationDemo.Options;
using Microsoft.Extensions.Options;

namespace ConfigurationDemo.Services;

public class UserService : IUserService
{
    private readonly UserSettingsOptions _settings;
    private readonly ILogger<UserService> _logger;

    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
        new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" },
        new User { Id = 4, Name = "Diana", Email = "diana@example.com" }
    ];

    public UserService(
        IOptions<UserSettingsOptions> options,
        ILogger<UserService> logger)
    {
        _settings = options.Value;
        _logger = logger;
    }

    public List<User> GetPagedUsers()
    {
        _logger.LogInformation(
            "Returning paged users. DefaultPageSize = {DefaultPageSize}, DefaultEmailDomain = {DefaultEmailDomain}",
            _settings.DefaultPageSize,
            _settings.DefaultEmailDomain);

        return _users
            .Take(_settings.DefaultPageSize)
            .ToList();
    }

    public User? Add(string name, string? email)
    {
        if (!_settings.AllowUserCreation)
        {
            _logger.LogWarning("User creation is disabled by configuration.");
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
