using ControllerApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();  // 启用 Controller 功能
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello Controller API");

app.MapControllers();   // 把 Controller 里的 route 映射到 ASP.NET Core routing system

app.Run();
