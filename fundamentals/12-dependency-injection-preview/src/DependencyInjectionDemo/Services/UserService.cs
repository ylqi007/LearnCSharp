using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public sealed class UserService
{
    private readonly IUserRepository _repository;
    private readonly IAppLogger _logger;

    public UserService(IUserRepository repository, IAppLogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public User? GetUser(string id)
    {
        _logger.Info($"Loading user {id}");
        return _repository.GetById(id);
    }

    public IReadOnlyList<User> GetActiveUsers()
    {
        return _repository.GetAll()
            .Where(user => user.IsActive)
            .ToList();
    }
}
