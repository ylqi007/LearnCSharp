# Solutions

## Exercise 01

```csharp
public sealed class TimestampLogger : IAppLogger
{
    public void Info(string message) => Console.WriteLine($"[{DateTime.UtcNow:O}] [INFO] {message}");
    public void Error(string message) => Console.WriteLine($"[{DateTime.UtcNow:O}] [ERROR] {message}");
}
```

## Exercise 02

```csharp
public interface IPaymentGateway
{
    bool Charge(decimal amount);
}

public sealed class FakePaymentGateway : IPaymentGateway
{
    public bool Charge(decimal amount) => true;
}

public sealed class PaymentService
{
    private readonly IPaymentGateway _gateway;

    public PaymentService(IPaymentGateway gateway)
    {
        _gateway = gateway;
    }

    public bool Pay(decimal amount)
    {
        return _gateway.Charge(amount);
    }
}
```

## Exercise 03

```csharp
public sealed class EmptyUserRepository : IUserRepository
{
    public User? GetById(string id) => null;
    public IReadOnlyList<User> GetAll() => [];
    public void Save(User user) { }
}
```

## Exercise 04

- Logger: usually singleton.
- DbContext: scoped, one per request.
- Email sender: often transient or singleton depending on implementation.
- UserService: usually scoped in ASP.NET Core when it uses scoped dependencies.
