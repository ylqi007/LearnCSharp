using OptionsPatternDemo.Models;

namespace OptionsPatternDemo.Services;

public interface IUserService
{
    List<User> GetAll();

    List<User> GetPagedUsers();

    User? GetById(int id);

    User? Add(string name, string? email);
}
