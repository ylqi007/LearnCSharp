using ApiVersioningDemo.Models;

namespace ApiVersioningDemo.Services;

public interface IUserStore
{
    List<User> GetAll();

    User? GetById(int id);

    User Add(User user);

    bool Deactivate(int id);
}
