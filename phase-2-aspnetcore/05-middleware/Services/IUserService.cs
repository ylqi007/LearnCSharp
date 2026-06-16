using MiddlewareDemo.Models;

namespace MiddlewareDemo.Services;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(int id);
    User Add(User user);
}
