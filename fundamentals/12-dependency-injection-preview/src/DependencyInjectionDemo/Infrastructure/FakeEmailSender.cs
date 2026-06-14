using DependencyInjectionDemo.Interfaces;

namespace DependencyInjectionDemo.Infrastructure;

public sealed class FakeEmailSender : IEmailSender
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine($"Fake email to {to}: {subject} - {body}");
    }
}
