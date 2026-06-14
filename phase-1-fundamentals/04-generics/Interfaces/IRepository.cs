using Generics.Models;

namespace Generics.Interfaces;

public interface IRepository<T>
    where T : IEntity   // Guarantees T.Id (entity.Id) is always available.
{
    void Add(T item);

    T? GetById(string id);

    IReadOnlyList<T> GetAll();
}
