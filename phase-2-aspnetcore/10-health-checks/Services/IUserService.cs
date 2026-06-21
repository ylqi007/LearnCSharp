using HealthChecksDemo.Models;

namespace HealthChecksDemo.Services;

public interface IUserService
{
    List<User> GetAll();
}
