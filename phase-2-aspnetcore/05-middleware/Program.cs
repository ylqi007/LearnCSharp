using MiddlewareDemo.Middleware;
using MiddlewareDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseRequestLogging();

app.MapGet("/", () => "Hello Middleware");
app.MapControllers();

app.Run();
