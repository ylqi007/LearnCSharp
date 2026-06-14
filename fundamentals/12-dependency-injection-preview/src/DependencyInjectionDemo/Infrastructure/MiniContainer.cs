namespace DependencyInjectionDemo.Infrastructure;

public sealed class MiniContainer
{
    private readonly Dictionary<Type, Func<object>> _registrations = new();

    public void Register<TService>(Func<TService> factory)
        where TService : notnull
    {
        _registrations[typeof(TService)] = () => factory();
    }

    public TService Resolve<TService>()
        where TService : notnull
    {
        if (!_registrations.TryGetValue(typeof(TService), out Func<object>? factory))
        {
            throw new InvalidOperationException($"No registration for {typeof(TService).Name}");
        }

        return (TService)factory();
    }
}
