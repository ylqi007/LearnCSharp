using GlobalExceptionDemo.Models;

namespace GlobalExceptionDemo.Services;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
    User Create(User user);
    void SimulateFailure();
}
