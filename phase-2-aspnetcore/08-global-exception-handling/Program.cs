using GlobalExceptionDemo.Middleware;
using GlobalExceptionDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseGlobalExceptionHandling();

app.MapGet("/", () => "Hello Global Exception Handling");

app.MapControllers();

app.Run();
