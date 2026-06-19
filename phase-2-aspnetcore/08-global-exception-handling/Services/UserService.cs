using GlobalExceptionDemo.Exceptions;
using GlobalExceptionDemo.Models;

namespace GlobalExceptionDemo.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    private readonly List<User> _users =
    [
        new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
    ];

    // UserService 有一个 logger
    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public List<User> GetAll()
    {
        _logger.LogInformation("Returning all users. Count = {UserCount}", _users.Count);
        return _users;
    }

    public User GetById(int id)
    {
        _logger.LogInformation("Looking up user. UserId = {UserId}", id);
        User? user = _users.FirstOrDefault(user => user.Id == id);

        if (user is null)
        {
            throw new UserNotFoundException(id);
        }

        return user;
    }

    public User Create(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
        {
            throw new InvalidUserException("User name is required.");
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            throw new InvalidUserException("User email is required.");
        }

        if (_users.Any(existingUser => existingUser.Id == user.Id))
        {
            throw new DuplicateUserException(user.Id);
        }

        _users.Add(user);
        _logger.LogInformation("User created. UserId = {UserId}, Email = {Email}", user.Id, user.Email);

        return user;
    }

    public void SimulateFailure()
    {
        throw new InvalidOperationException("This is an unexpected system failure.");
    }
}
