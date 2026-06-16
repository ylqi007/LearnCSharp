using ConfigurationDemo.Models;

namespace ConfigurationDemo.Services;

public interface IUserService
{
    List<User> GetPagedUsers();

    User? Add(string name, string? email);
}
