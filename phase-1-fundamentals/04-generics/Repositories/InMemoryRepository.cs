using Generics.Interfaces;
using Generics.Models;

namespace Generics.Repositories;

public class InMemoryRepository<T> : IRepository<T>
    where T : IEntity   // Guarantees T.Id (entity.Id) is always available.
{
    private readonly Dictionary<string, T> _items = new();

    public void Add(T item)
    {
        _items[item.Id] = item;
    }

    public T? GetById(string id)
    {
        return _items.TryGetValue(id, out var item)
            ? item
            : default;
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items.Values.ToList();
    }
}
