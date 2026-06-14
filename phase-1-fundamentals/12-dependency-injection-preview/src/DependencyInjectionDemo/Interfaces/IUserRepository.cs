using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Interfaces;

public interface IUserRepository
{
    User? GetById(string id);
    IReadOnlyList<User> GetAll();
    void Save(User user);
}
