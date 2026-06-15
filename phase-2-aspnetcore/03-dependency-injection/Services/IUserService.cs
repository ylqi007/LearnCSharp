using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public interface IUserService
{
    List<User> GetAll();

    User? GetById(int id);

    User Add(User user);

    bool Delete(int id);
}
