using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Models;

namespace DependencyInjectionDemo.Services;

public sealed class NotificationService
{
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger _logger;

    public NotificationService(IEmailSender emailSender, IAppLogger logger)
    {
        _emailSender = emailSender;
        _logger = logger;
    }

    public void SendWelcomeEmail(User user)
    {
        _logger.Info($"Sending welcome email to {user.Email}");
        _emailSender.Send(user.Email, "Welcome", $"Hi {user.Name}, welcome!");
    }
}
