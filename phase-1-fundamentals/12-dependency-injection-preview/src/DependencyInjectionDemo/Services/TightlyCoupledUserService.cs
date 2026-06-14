using DependencyInjectionDemo.Models;
using DependencyInjectionDemo.Repositories;

namespace DependencyInjectionDemo.Services;

public sealed class TightlyCoupledUserService
{
    private readonly UserRepository _repository = new();

    public User? GetUser(string id)
    {
        return _repository.GetById(id);
    }
}
