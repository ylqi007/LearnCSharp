using LoggingDemo.Models;

namespace LoggingDemo.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
        new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" }
    ];

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public List<User> GetAll()
    {
        _logger.LogDebug(
            "Returning all users. Count = {UserCount}",
            _users.Count);

        return _users;
    }

    public User? GetById(int id)
    {
        _logger.LogDebug(
            "Looking up user by id. UserId = {UserId}",
            id);

        User? user = _users.FirstOrDefault(user => user.Id == id);

        if (user is null)
        {
            _logger.LogWarning(
                "User was not found. UserId = {UserId}",
                id);
        }
        else
        {
            _logger.LogInformation(
                "User was found. UserId = {UserId}, Email = {Email}",
                user.Id,
                user.Email);
        }

        return user;
    }

    public User Add(User user)
    {
        _logger.LogInformation(
            "Creating user. UserId = {UserId}, Email = {Email}",
            user.Id,
            user.Email);

        _users.Add(user);

        _logger.LogInformation(
            "User created successfully. UserId = {UserId}, TotalUsers = {UserCount}",
            user.Id,
            _users.Count);

        return user;
    }
}
