using LoggingDemo.Middleware;
using LoggingDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();    // 注册 service

var app = builder.Build();

app.UseRequestLogging();    // 注册 middleware

app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogInformation("Root endpoint was called.");

    return "Hello Logging";
});

app.MapControllers();

app.Run();
