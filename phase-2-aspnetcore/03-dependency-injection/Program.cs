using DependencyInjectionDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register abstraction + implementation.
// When ASP.NET Core sees IUserService,
// it will inject UserService.
builder.Services.AddScoped<IUserService, UserService>();    // 当某个地方需要 IUserService，请提供 UserService
// Scoped 表示：每一个 HTTP Request 创建一个 UserService instance
// Request A -> UserService instance A
// Request B -> UserService instance B


var app = builder.Build();

app.MapGet("/", () => "Hello Dependency Injection");

app.MapControllers();

app.Run();
